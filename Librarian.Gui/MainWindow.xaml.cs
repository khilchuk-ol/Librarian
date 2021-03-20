using Librarian.Gui.ViewModels;
using System.Windows;

namespace Librarian.Gui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainFrame_Loaded(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.Navigation.NavigateTo(ViewModelLocator.HomePage);
        }
    }
}
