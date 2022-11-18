using GaspromDiagnostics.Model;
using GaspromDiagnostics.Services;
using GaspromDiagnostics.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace GaspromDiagnostics.ViewModel
{
    public class MainViewModel : ViewModelBase
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

        // команда импорта из файла
        private RelayCommand importFromFileCommand;
        public RelayCommand ImportFromFileCommand
        {
            get
            {
                return importFromFileCommand ??
                  (importFromFileCommand = new RelayCommand(obj =>
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

        // команда экспорта в файл
        private RelayCommand exportToFileCommand;
        public RelayCommand ExportToFileCommand
        {
            get
            {
                return exportToFileCommand ??
                  (exportToFileCommand = new RelayCommand(obj =>
                  {
                      try
                      {
                          if (dialogService.SaveFileDialog() == true)
                          {
                              fileService.Save(dialogService.FilePath, AllObjects);

                              dialogService.ShowMessage($"Выгружено {AllObjects.Count} объектов");
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

        public MainViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;

            allObjects = DataWorker.GetAllObjects();
        }
    }
}
