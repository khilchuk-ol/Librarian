using Librarian.Gui.Models;
using Librarian.Gui.Models.Abstract;
using Librarian.Gui.ViewModels.Enums;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class BooksViewModel : BaseModel
    {
        #region fileds
        private string _query;
        private BookFindType _type;
        private int _bookId;
        private ICommand _getBookCommand;
        private ICommand _findBooksByTitle;
        private ICommand _findBooksByAuthor;
        private ObservableCollection<BookModel> _books;
        #endregion

        #region properties
        public string Query
        {
            get => _query;
            set
            {
                if(value != _query)
                {
                    _query = value;
                    OnPropertyChanged(nameof(Query));
                }
            }
        }

        public int BookId
        {
            get => _bookId;
            set
            {
                if (value != _bookId)
                {
                    _bookId = value;
                    OnPropertyChanged(nameof(BookId));
                }
            }
        }

        public BookFindType BookFindType
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged(nameof(BookFindType));
                }
            }
        }

        public ICommand GetBookCommand
        {
            get => _getBookCommand; 
            set
            {
                if (value != _getBookCommand)
                {
                    _getBookCommand = value;
                    OnPropertyChanged(nameof(GetBookCommand));
                }
            }
        }
        public ICommand FindBooksByAuthor
        {
            get => _findBooksByAuthor; 
            set
            {
                if (value != _findBooksByAuthor)
                {
                    _findBooksByAuthor = value;
                    OnPropertyChanged(nameof(FindBooksByAuthor));
                }
            }
        }
        public ICommand FindBooksByTitle
        {
            get => _findBooksByTitle; 
            set
            {
                if (value != _findBooksByTitle)
                {
                    _findBooksByTitle = value;
                    OnPropertyChanged(nameof(FindBooksByTitle));
                }
            }
        }
        public ObservableCollection<BookModel> Books
        {
            get => _books;
            set
            {
                if(_books != value)
                {
                    _books = value;
                    OnPropertyChanged(nameof(Books));
                }
            }
        }
        #endregion
    }
}
