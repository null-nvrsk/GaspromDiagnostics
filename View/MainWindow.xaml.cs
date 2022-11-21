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
        //private List<Object> objects;
        public static ListView AllObjectsView;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(
                new DefaultDialogService(),
                new DataFileService()
                );
            AllObjectsView = ViewAllObjects;

            //objects = new List<Object>
            //{
            //    new Object { Id=1, Name="Коррозия", Distance=2, Angle=7, Width=3, Height=2, IsDefect=true },
            //    new Object { Id=2, Name="Верт.шов", Distance=5, Angle=7, Width=0, Height=4, IsDefect=false },
            //    new Object { Id=3, Name="Гор.шов", Distance=5, Angle=1, Width=4, Height=0, IsDefect=false }
            //};
            //objectsGrid.ItemsSource = objects;
            //objectList.ItemsSource = objects;
        }

    }
}
