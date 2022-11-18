using GaspromDiagnostics.Services;
using GaspromDiagnostics.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GaspromDiagnostics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private List<Object> objects;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel(
                new DefaultDialogService(),
                new CsvFileService()
                );

            //objects = new List<Object>
            //{
            //    new Object { Id=1, Name="Коррозия", Distance=2, Angle=7, Width=3, Heigth=2, IsDefect=true },
            //    new Object { Id=2, Name="Верт.шов", Distance=5, Angle=7, Width=0, Heigth=4, IsDefect=false },
            //    new Object { Id=3, Name="Гор.шов", Distance=5, Angle=1, Width=4, Heigth=0, IsDefect=false }
            //};
            //objectsGrid.ItemsSource = objects;
            //objectList.ItemsSource = objects;
        }

    }
}
