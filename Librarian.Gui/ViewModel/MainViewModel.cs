using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Librarian.Gui.ViewModel
{
    public class MainViewModel
    {
        public bool ShowHome { get; private set; }
        public bool ShowBooks { get; private set; }
        public bool ShowAuthors { get; private set; }
        public bool ShowGenres { get; private set; }
        public bool ShowReaders { get; private set; }

        public MainViewModel()
        {
            ShowHome = true;
        }
    }
}
