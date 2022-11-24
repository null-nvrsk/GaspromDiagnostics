using GaspromDiagnostics.Services;
using GaspromDiagnostics.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace GaspromDiagnostics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static ListView AllObjectsView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(
                new DefaultDialogService(),
                new DataFileService()
                );
            AllObjectsView = ViewAllObjects;
        }

    }
}
