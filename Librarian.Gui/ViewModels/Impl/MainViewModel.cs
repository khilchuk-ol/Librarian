using GalaSoft.MvvmLight.Views;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;

namespace Librarian.Gui.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region fields
        private HomeViewModel _homeViewModel;
        private BooksViewModel _booksViewModel;
        private ReadersViewModel _readersViewModel;
        private BookViewModel _bookViewModel;
        #endregion

        #region properties
        public INavigationService Navigation { get; }

        public HomeViewModel HomeViewModel
        {
            get => _homeViewModel;
            set
            {
                if(value != _homeViewModel)
                {
                    _homeViewModel = value;
                    OnPropertyChanged(nameof(HomeViewModel));
                }
            }
        }
        public BooksViewModel BooksViewModel
        {
            get => _booksViewModel;
            set
            {
                if (value != _booksViewModel)
                {
                    _booksViewModel = value;
                    OnPropertyChanged(nameof(BooksViewModel));
                }
            }
        }
        public ReadersViewModel ReadersViewModel
        {
            get => _readersViewModel;
            set
            {
                if (value != _readersViewModel)
                {
                    _readersViewModel = value;
                    OnPropertyChanged(nameof(ReadersViewModel));
                }
            }
        }
        public BookViewModel BookViewModel
        {
            get => _bookViewModel;
            set
            {
                if (value != _bookViewModel)
                {
                    _bookViewModel = value;
                    OnPropertyChanged(nameof(BookViewModel));
                }
            }
        }
        #endregion

        public MainViewModel(INavigationService navigation,
                             IBookModelService bookService, IAuthorModelService authorService, 
                             IReaderModelService readerService, IRecordModelService recordService)
        {
            Navigation = navigation;
            HomeViewModel = new HomeViewModel();
            BooksViewModel = new BooksViewModel(bookService, authorService);
            ReadersViewModel = new ReadersViewModel(readerService);
            BookViewModel = new BookViewModel(bookService);
        }
    }
}
