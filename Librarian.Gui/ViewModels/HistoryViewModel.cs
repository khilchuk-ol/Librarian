using Librarian.Gui.Command;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class HistoryViewModel : ViewModel
    {
        #region fields
        private int _selectedReaderId;
        private ObservableCollection<RecordModel> _historyBookRecords;

        private int _amountToDisplay;
        private int _offset;

        private ICommand _moveNextCommand;
        private ICommand _moveBackCommand;

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
                    GetHistory();
                    OnPropertyChanged(nameof(SelectedReaderId));
                    OnPropertyChanged(nameof(HistoryBookRecords));
                }
            }
        }
        public ObservableCollection<RecordModel> HistoryBookRecords
        {
            get => new ObservableCollection<RecordModel>(_historyBookRecords.Skip(_offset).Take(_amountToDisplay));
            set
            {
                if (value != _historyBookRecords)
                {
                    _historyBookRecords = value;
                    OnPropertyChanged(nameof(HistoryBookRecords));
                }
            }
        }

        public int Offset
        {
            get => _offset;
            set
            {
                if (value != _offset)
                {
                    _offset = value;
                    OnPropertyChanged(nameof(Offset));
                    OnPropertyChanged(nameof(HistoryBookRecords));
                }
            }
        }
        public int AmountToDisplay
        {
            get => _amountToDisplay;
            set
            {
                if (value != _amountToDisplay)
                {
                    _amountToDisplay = value;
                    OnPropertyChanged(nameof(AmountToDisplay));
                    OnPropertyChanged(nameof(HistoryBookRecords));
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
                        _ => Offset + _amountToDisplay < _historyBookRecords.Count);
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

        public HistoryViewModel(IRecordModelService recordService)
        {
            Name = "History";
            Offset = 0;
            AmountToDisplay = 9;

            _recordService = recordService ?? throw new ArgumentNullException($"Cannot pass null as a record service for {nameof(HistoryViewModel)}"); ;
        }

        private void GetHistory()
        {
            HistoryBookRecords = _recordService.GetPast(SelectedReaderId);
        }
    }
}
