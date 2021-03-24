using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class ReaderViewModel : ViewModel
    {
        #region fields
        private ReaderModel _selectedReader;
        private int _selectedReaderId;
        private ObservableCollection<RecordModel> _curentlyBorrowedBookRecords;

        private ReadersViewModel _parent;
        
        private IReaderModelService _readerService;
        private IRecordModelService _recordService;
        #endregion

        #region properties
        public int SelectedReaderId
        {
            get => _selectedReaderId;
            set
            {
                if (value != _selectedReaderId)
                {
                    _selectedReaderId = value;
                    GetReader();
                    OnPropertyChanged(nameof(SelectedReaderId));
                    OnPropertyChanged(nameof(SelectedReader));
                    OnPropertyChanged(nameof(CurrentlyBorrowedBookRecords));
                }
            }
        }
        public ReaderModel SelectedReader
        {
            get => _selectedReader;
            set
            {
                if (value != _selectedReader)
                {
                    _selectedReader = value;
                    OnPropertyChanged(nameof(SelectedReader));
                }
            }
        }
        public ObservableCollection<RecordModel> CurrentlyBorrowedBookRecords
        {
            get => _curentlyBorrowedBookRecords;
            set
            {
                if (value != _curentlyBorrowedBookRecords)
                {
                    _curentlyBorrowedBookRecords = value;
                    OnPropertyChanged(nameof(CurrentlyBorrowedBookRecords));
                }
            }
        }

        public ICommand DisplayHistoryCommand
        {
            get => _parent.DisplayHistoryCommand;
        }
        #endregion

        public ReaderViewModel(ReadersViewModel parent, IReaderModelService readerService, IRecordModelService recordService)
        {
            Name = "Reader";
            _readerService = readerService;
            _recordService = recordService;
            _parent = parent;
        }

        private void GetReader()
        {
            SelectedReader = _readerService.GetReaderWithInfo(SelectedReaderId);
            CurrentlyBorrowedBookRecords = _recordService.GetActive(SelectedReaderId);
        }
    }
}
