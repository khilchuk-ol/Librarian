using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using System;

namespace Librarian.Gui.ViewModels
{
    public class BookViewModel : ViewModel
    {
        #region fields
        private int _bookId;
        private BookModel _book;

        private IBookModelService _service;
        #endregion

        #region properties
        public int BookId
        {
            get => _bookId;
            set
            {
                if(value != _bookId)
                {
                    _bookId = value;
                    GetBook();
                    OnPropertyChanged(nameof(BookId));
                    OnPropertyChanged(nameof(Book));
                }
            }
        }
        public BookModel Book
        {
            get => _book;
            set
            {
                if (value != _book)
                {
                    _book = value;
                    OnPropertyChanged(nameof(Book));
                }
            }
        }
        #endregion

        public BookViewModel(IBookModelService service)
        {
            Name = "Book";
            _service = service ?? throw new ArgumentNullException($"Cannot pass null as a service for {nameof(BooksViewModel)}");
        }

        private void GetBook()
        {
            Book = _service.GetBookWithInfo(BookId);
        }
    }
}
