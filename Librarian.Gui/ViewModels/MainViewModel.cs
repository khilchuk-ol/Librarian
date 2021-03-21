using Librarian.Gui.Command;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class MainViewModel : ViewModel
    {
        #region fields
        private ICommand _changePageCommand;

        private ViewModel _currentPageViewModel;
        private List<ViewModel> _pageViewModels = new List<ViewModel>();
        #endregion

        #region properties
        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                {
                    _changePageCommand = new RelayCommand(
                        p => ChangeViewModel((ViewModel)p),
                        p => p is ViewModel);
                }

                return _changePageCommand;
            }
        }
        public List<ViewModel> PageViewModels
        {
            get
            {
                if (_pageViewModels == null)
                    _pageViewModels = new List<ViewModel>();

                return _pageViewModels;
            }
        }
        public ViewModel CurrentPageViewModel
        {
            get => _currentPageViewModel;
            set
            {
                if (_currentPageViewModel != value)
                {
                    _currentPageViewModel = value;
                    OnPropertyChanged(nameof(CurrentPageViewModel));
                }
            }
        }
        #endregion

        public MainViewModel(IBookModelService bookService, IAuthorModelService authorService, 
                             IReaderModelService readerService, IRecordModelService recordService)
        {
            _pageViewModels.Add(new HomeViewModel());
            _pageViewModels.Add(new BooksViewModel(bookService, authorService));
            _pageViewModels.Add(new ReadersViewModel(readerService, recordService));

            CurrentPageViewModel = _pageViewModels.Find(vm => vm.Name == "Home");
        }

        private void ChangeViewModel(ViewModel viewModel)
        {
            if (!PageViewModels.Contains(viewModel))
                PageViewModels.Add(viewModel);

            CurrentPageViewModel = PageViewModels
                .FirstOrDefault(vm => vm == viewModel);
        }
    }
}
