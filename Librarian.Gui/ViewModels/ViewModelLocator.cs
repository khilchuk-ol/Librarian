using Librarian.Gui.Controls.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Librarian.Gui.ViewModels
{
    public class ViewModelLocator
    {
        private static Dictionary<ControlType, Lazy<UserControl>> _controls =
            new Dictionary<ControlType, Lazy<UserControl>>();

        private MainViewModel _mainViewModel;

        public const string HomePage = "Home";
        public const string BooksPage = "Books";
        public const string ReadersPage = "Readers";
        public const string BookInfoPage = "Book";

        public MainViewModel Main
        {
            get => _mainViewModel;
        }

        public ViewModelLocator(MainViewModel mainViewModel)
        {
            _mainViewModel = mainViewModel;
        }
    }
}
