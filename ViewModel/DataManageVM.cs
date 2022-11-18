using GaspromDiagnostics.Model;
using GaspromDiagnostics.Services;
using GaspromDiagnostics.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace GaspromDiagnostics.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        Object selectedObject;

        IFileService fileService;
        IDialogService dialogService;

        // все объекты
        private List<Object> allObjects;
        public List<Object> AllObjects
        {
            get { return allObjects; }
            set
            {
                allObjects = value;
                NotifyPropertyChanged("AllObjects");
            }
        }

        #region COMMANDS TO OPEN WINDOWS
        private RelayCommand openAddNewObjectWnd;
        public RelayCommand OpenAddNewObjectWnd
        {
            get
            {
                return openAddNewObjectWnd ?? new RelayCommand(obj =>
                {
                    OpenAddObjectWindowMethod();
                }
                );
            }
        }

        private RelayCommand openEditObjectWnd;
        public RelayCommand OpenEditObjectWnd
        {
            get
            {
                return openEditObjectWnd ?? new RelayCommand(obj =>
                {
                    OpenEditObjectWindowMethod();
                }
                );
            }
        }
        #endregion

        #region COMMANDS TO IMPORT/EXPORT FILES

        // команда открытия файла
        private RelayCommand openCsvFileCommand;
        public RelayCommand OpenCsvFileCommand
        {
            get
            {
                return openCsvFileCommand ??
                  (openCsvFileCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.OpenFileDialog() == true)
                          {
                              var loadedObjects = fileService.Open(dialogService.FilePath);
                              AllObjects.Clear();
                              AllObjects.AddRange(loadedObjects);
                              
                              dialogService.ShowMessage($"Загружено {AllObjects.Count} объектов");
                          }
                      }
                      catch (Exception ex)
                      {
                          dialogService.ShowMessage(ex.Message);
                      }
                  }));
            }
        }


        #endregion

        #region METHODS TO OPEN/EDIT WINDOW
        // Методы открытия окон
        private void OpenAddObjectWindowMethod()
        {
            AddNewObjectWindow newObjectWindow = new AddNewObjectWindow();
            SetCenterPositionAndOpen(newObjectWindow);
        }

        // Окно редактирования
        private void OpenEditObjectWindowMethod()
        {
            EditObjectWindow editObjectWindow = new EditObjectWindow();
            SetCenterPositionAndOpen(editObjectWindow);
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }
        #endregion

        public DataManageVM(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            allObjects = DataWorker.GetAllObjects();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(String propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
