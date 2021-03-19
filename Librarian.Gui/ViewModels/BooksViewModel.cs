using Librarian.Domain.Services.Abstract;
using Librarian.Gui.Command;
using Librarian.Gui.Models;
using Librarian.Gui.ViewModels.Abstract;
using Librarian.Gui.ViewModels.Enums;
using Librarian.Mappers.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class BooksViewModel : ViewModel
    {
        #region fileds
        private string _query;
        private BookFindType? _type;
        private int _selectedBookId;
        private BookModel _selectedBook;
        private ObservableCollection<BookModel> _books;
        private int _amountToDisplay;
        private int _offset;

        private ICommand _getBookCommand;
        private ICommand _findBooksCommand;
        private ICommand _setFindTypeToTitleCommand;
        private ICommand _setFindTypeToAuthorCommand;
        private ICommand _moveNextCommand;
        private ICommand _moveBackCommand;

        private IBookService _bookService;
        private IAuthorService _authorService;
        private IBookMapper _bookMapper;
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

        public int SelectedBookId
        {
            get => _selectedBookId;
            set
            {
                if (value != _selectedBookId)
                {
                    _selectedBookId = value;
                    OnPropertyChanged(nameof(SelectedBookId));
                }
            }
        }
        public BookModel SelectedBook
        {
            get => _selectedBook;
            set
            {
                if (value != _selectedBook)
                {
                    _selectedBook = value;
                    OnPropertyChanged(nameof(SelectedBook));
                }
            }
        }

        public BookFindType? BookFindType
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
            get
            {
                if(_getBookCommand == null)
                {
                    _getBookCommand = new RelayCommand(
                        _ => GetBook(),
                        _ => SelectedBookId > 0);
                }
                return _getBookCommand;
            }
        }
        public ICommand FindBooksCommand
        {
            get
            {
                if (_findBooksCommand == null)
                {
                    _findBooksCommand = new RelayCommand(
                        _ => FindBooks(),
                        _ => Query != null && BookFindType.HasValue);
                }
                return _findBooksCommand;
            }
        }
        
        public ICommand SetFindTypeToTitleCommand
        {
            get
            {
                if (_setFindTypeToTitleCommand == null)
                {
                    _setFindTypeToTitleCommand = new RelayCommand(
                        _ => BookFindType = Enums.BookFindType.ByTitle);
                }
                return _setFindTypeToTitleCommand;
            }
        }
        public ICommand SetFindTypeToAuthorCommand
        {
            get
            {
                if (_setFindTypeToAuthorCommand == null)
                {
                    _setFindTypeToAuthorCommand = new RelayCommand(
                        _ => BookFindType = Enums.BookFindType.ByAuthor);
                }
                return _setFindTypeToAuthorCommand;
            }
        }

        public ObservableCollection<BookModel> Books
        {
            get => new ObservableCollection<BookModel>(_books.Skip(_offset).Take(_amountToDisplay));
            set
            {
                if(_books != value)
                {
                    _books = value;
                    OnPropertyChanged(nameof(Books));
                }
            }
        }
        public int Offset
        {
            get => _offset;
            set
            {
                if(value != _offset)
                {
                    _offset = value;
                    OnPropertyChanged(nameof(Offset));
                    OnPropertyChanged(nameof(Books));
                }
            }
        }
        public int AmountToDisplay
        {
            get => _amountToDisplay;
            set
            {
                if(value != _amountToDisplay)
                {
                    _amountToDisplay = value;
                    OnPropertyChanged(nameof(AmountToDisplay));
                    OnPropertyChanged(nameof(Books));
                }
            }
        }
        public ICommand MoveNextCommand
        {
            get
            {
                if (_moveNextCommand == null)
                {
                    _moveNextCommand = new RelayCommand(
                        _ => Offset += _amountToDisplay,
                        _ => Offset + _amountToDisplay <= _books.Count);
                }
                return _moveNextCommand;
            }
        }
        public ICommand MoveBackCommand
        {
            get
            {
                if (_moveBackCommand == null)
                {
                    _moveBackCommand = new RelayCommand(
                        _ => Offset -= _amountToDisplay,
                        _ => Offset - _amountToDisplay > 0);
                }
                return _moveBackCommand;
            }
        }
        #endregion

        public BooksViewModel(IBookService bService, IAuthorService aService, IBookMapper bookMapper)
        {
            Name = "Books";
            Query = "";
            Offset = 0;
            AmountToDisplay = 9;
            BookFindType = Enums.BookFindType.ByTitle;
            _bookService = bService ?? throw new ArgumentNullException("Cannot pass null as a book service for BooksViewModel");
            _authorService = aService ?? throw new ArgumentNullException("Cannot pass null as an author service for BooksViewModel");
            _bookMapper = bookMapper ?? throw new ArgumentNullException("Cannot pass null as an abook mapper for BooksViewModel");
            _books = new ObservableCollection<BookModel>(_bookService.GetBooks().Select(b => _bookMapper.Map(b)));
        }

        private void GetBook()
        {
            var book = _bookService.GetBookWithInfo(SelectedBookId);
            SelectedBook = _bookMapper.Map(book);
        }

        private void FindBooks()
        {
            if(BookFindType == Enums.BookFindType.ByTitle)
            {
                FindBooksByTitle();
            }
            if(BookFindType == Enums.BookFindType.ByAuthor)
            {
                FindBooksByAuthor();
            }
        }
        private void FindBooksByTitle()
        {
            var res = _bookService.FindBooksByTitle(Query);
            Books = new ObservableCollection<BookModel>(res.Select(b => _bookMapper.Map(b)));
            return;
        }
        private void FindBooksByAuthor()
        {
            var authors = _authorService.FindAuthorsByName(Query);

            if (authors.Count() > 0)
            {
                var res = authors.SelectMany(a => _bookService.FindBooksByAuthor(a)).ToHashSet();
                Books = new ObservableCollection<BookModel>(res.Select(b => _bookMapper.Map(b)));
                return;
            }
        }
    }
}
