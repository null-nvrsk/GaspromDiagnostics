using GaspromDiagnostics.ViewModel;
using System.Text.RegularExpressions;
using System.Windows;

namespace GaspromDiagnostics.View
{
    /// <summary>
    /// Interaction logic for EditObjectWindow.xaml
    /// </summary>
    public partial class EditObjectWindow : Window
    {
        public EditObjectWindow(Object objectToEdit)
        {
            InitializeComponent();

            DataContext = new MainViewModel();

            MainViewModel.SelectedObject = objectToEdit;
            MainViewModel.ObjectId = objectToEdit.Id;
            MainViewModel.ObjectName = objectToEdit.Name;
            MainViewModel.ObjectDistance = objectToEdit.Distance;
            MainViewModel.ObjectAngle = objectToEdit.Angle;
            MainViewModel.ObjectWidth = objectToEdit.Width;
            MainViewModel.ObjectHeight = objectToEdit.Height;
            MainViewModel.ObjectIsDefect = objectToEdit.IsDefect;
        }

        private void PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
