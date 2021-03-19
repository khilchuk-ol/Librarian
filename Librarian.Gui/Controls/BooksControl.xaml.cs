using Librarian.Gui.ViewModels;
using System.Windows;
using System.Windows.Controls;

namespace Librarian.Gui.Controls
{
    /// <summary>
    /// Interaction logic for BooksControl.xaml
    /// </summary>
    public partial class BooksControl : UserControl
    {
        public BooksControl()
        {
            InitializeComponent();
            /*var vm = (BooksViewModel)DataContext;
            vm.AmountToDisplay = (int)((Height - 100) / 40);*/
            SizeChanged += OnWindowSizeChanged;
        }

        protected void OnWindowSizeChanged(object sender, SizeChangedEventArgs e)
        {
            var vm = (BooksViewModel)DataContext;
            vm.AmountToDisplay = (int)((e.NewSize.Height - 20) / 40);
        }
    }
}
