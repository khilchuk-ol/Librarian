using Librarian.Gui.Command;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using Librarian.Gui.ViewModels.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class BooksViewModel : ViewModel
    {
        #region fields
        private string _query;
        private BookFindType _type;
        private ObservableCollection<BookModel> _books;
        private int _amountToDisplay;
        private int _offset;
        private int _selectedBookId;
        private BookModel _selectedBook;

        private ICommand _findBooksCommand;
        private ICommand _setFindTypeToTitleCommand;
        private ICommand _setFindTypeToAuthorCommand;
        private ICommand _moveNextCommand;
        private ICommand _moveBackCommand;
        private ICommand _displayAllCommand;
        private ICommand _displayBookCommand;

        private IBookModelService _bookService;
        private IAuthorModelService _authorService;
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

        public ICommand FindBooksCommand
        {
            get
            {
                if (_findBooksCommand == null)
                {
                    _findBooksCommand = new RelayCommand(
                        _ => FindBooks(),
                        _ => Query != null);
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
                        _ => BookFindType = BookFindType.ByTitle);
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
                        _ => BookFindType = BookFindType.ByAuthor);
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
                        _ => Offset + _amountToDisplay < _books.Count);
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
                        _ => Offset - _amountToDisplay >= 0);
                }
                return _moveBackCommand;
            }
        }
        public ICommand DisplayAllCommand
        {
            get
            {
                if (_displayAllCommand == null)
                {
                    _displayAllCommand = new RelayCommand(
                        _ => DisplayAll());
                }
                return _displayAllCommand;
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
                    GetBook();
                    OnPropertyChanged(nameof(SelectedBookId));
                    OnPropertyChanged(nameof(SelectedBook));
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
        public ICommand DisplayBookCommand
        {
            get
            {
                if (_displayBookCommand == null)
                {
                    _displayBookCommand = new RelayCommand(
                        param => SelectedBookId = (int)param,
                        param => param is int);
                }
                return _displayBookCommand;
            }
        }
        #endregion

        public BooksViewModel(IBookModelService bService, IAuthorModelService aService)
        {
            Name = "Books";
            Query = "";
            Offset = 0;
            AmountToDisplay = 9;
            BookFindType = BookFindType.ByTitle;
            _bookService = bService ?? throw new ArgumentNullException($"Cannot pass null as a book service for {nameof(BooksViewModel)}");
            _authorService = aService ?? throw new ArgumentNullException($"Cannot pass null as an author service for {nameof(BooksViewModel)}");
            _books = _bookService.GetBooks();
        }

        private void FindBooks()
        {
            if(BookFindType == BookFindType.ByTitle)
            {
                FindBooksByTitle();
            }
            if(BookFindType == BookFindType.ByAuthor)
            {
                FindBooksByAuthor();
            }
        }
        private void FindBooksByTitle()
        {
            Books = _bookService.FindBooksByTitle(Query);
        }
        private void FindBooksByAuthor()
        {
            var authors = _authorService.FindAuthorsByName(Query);
            Books = new ObservableCollection<BookModel>(authors.SelectMany(a => _bookService.FindBooksByAuthor(a.Id)));
        }

        private void DisplayAll()
        {
            Offset = 0;
            Books = _bookService.GetBooks();
        }

        private void GetBook()
        {
            SelectedBook = _bookService.GetBookWithInfo(SelectedBookId);
        }
    }
}
