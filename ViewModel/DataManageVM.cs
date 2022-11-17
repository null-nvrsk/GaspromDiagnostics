using GaspromDiagnostics.Model;
using GaspromDiagnostics.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GaspromDiagnostics.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        // все объекты
        private List<Object> allObjects = DataWorker.GetAllObjects();
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
