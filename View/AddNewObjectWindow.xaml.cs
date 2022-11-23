using GaspromDiagnostics.ViewModel;
using System.Windows;

namespace GaspromDiagnostics.View
{
    /// <summary>
    /// Interaction logic for AddNewObjectWindow.xaml
    /// </summary>
    public partial class AddNewObjectWindow : Window
    {
        public AddNewObjectWindow()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
            MainViewModel.ObjectId = 0;
            MainViewModel.ObjectName = null;
            MainViewModel.ObjectDistance = 0;
            MainViewModel.ObjectAngle = 0;
            MainViewModel.ObjectWidth = 0;
            MainViewModel.ObjectHeight = 0;
            MainViewModel.ObjectIsDefect = false;
        }
    }
}
