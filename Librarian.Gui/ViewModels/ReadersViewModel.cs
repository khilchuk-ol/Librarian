using Librarian.Gui.Command;
using Librarian.Gui.Models;
using Librarian.Gui.Services.Abstract;
using Librarian.Gui.ViewModels.Abstract;
using Librarian.Gui.ViewModels.Enums;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Input;

namespace Librarian.Gui.ViewModels
{
    public class ReadersViewModel : ViewModel
    {
        #region fields
        private string _query;
        private ReaderFindType _type;
        private ObservableCollection<ReaderModel> _readers;
        private int _amountToDisplay;
        private int _offset;

        private ICommand _findReadersCommand;
        private ICommand _setFindTypeToNameCommand;
        private ICommand _setFindTypeToTicketCommand;
        private ICommand _moveNextCommand;
        private ICommand _moveBackCommand;
        private ICommand _displayAllCommand;

        private IReaderModelService _readerService;
        #endregion

        #region properties
        public string Query
        {
            get => _query;
            set
            {
                if (value != _query)
                {
                    _query = value;
                    OnPropertyChanged(nameof(Query));
                }
            }
        }

        public ReaderFindType ReaderFindType
        {
            get => _type;
            set
            {
                if (value != _type)
                {
                    _type = value;
                    OnPropertyChanged(nameof(ReaderFindType));
                }
            }
        }

        public ICommand FindReadersCommand
        {
            get
            {
                if (_findReadersCommand == null)
                {
                    _findReadersCommand = new RelayCommand(
                        _ => FindReaders(),
                        _ => Query != null && (ReaderFindType != ReaderFindType.ByTicketNumber || Regex.IsMatch(Query, @"^[0-9]*$")));
                }
                return _findReadersCommand;
            }
        }

        public ICommand SetFindTypeToNameCommand
        {
            get
            {
                if (_setFindTypeToNameCommand == null)
                {
                    _setFindTypeToNameCommand = new RelayCommand(
                        _ => ReaderFindType = ReaderFindType.ByName);
                }
                return _setFindTypeToNameCommand;
            }
        }
        public ICommand SetFindTypeToTicketCommand
        {
            get
            {
                if (_setFindTypeToTicketCommand == null)
                {
                    _setFindTypeToTicketCommand = new RelayCommand(
                        _ => ReaderFindType = ReaderFindType.ByTicketNumber,
                        _ => Regex.IsMatch(Query, @"^[0-9]*$"));
                }
                return _setFindTypeToTicketCommand;
            }
        }

        public ObservableCollection<ReaderModel> Readers
        {
            get => new ObservableCollection<ReaderModel>(_readers.Skip(_offset).Take(_amountToDisplay));
            set
            {
                if (_readers != value)
                {
                    _readers = value;
                    OnPropertyChanged(nameof(Readers));
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
                    OnPropertyChanged(nameof(Readers));
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
                    OnPropertyChanged(nameof(Readers));
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
                        _ => Offset + _amountToDisplay < _readers.Count);
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
        #endregion

        public ReadersViewModel(IReaderModelService rService)
        {
            Name = "Readers";
            Query = "";
            Offset = 0;
            AmountToDisplay = 9;
            ReaderFindType = ReaderFindType.ByName;
            _readerService = rService ?? throw new ArgumentNullException($"Cannot pass null as a reader service for {nameof(ReadersViewModel)}");
            _readers = _readerService.GetReaders();
        }

        private void FindReaders()
        {
            if(ReaderFindType == ReaderFindType.ByName)
            {
                FindReadersByName();
            }
            if(ReaderFindType == ReaderFindType.ByTicketNumber)
            {
                FindReadersByTicket();
            }
        }
        private void FindReadersByName()
        {
            Readers = _readerService.FindReadersByName(Query);
        }
        private void FindReadersByTicket()
        {
            if(int.TryParse(Query, out int number))
            {
                Readers = _readerService.FindReaderByTicket(number);
                return;
            }

            Readers = new ObservableCollection<ReaderModel>();
        }

        private void DisplayAll()
        {
            Offset = 0;
            Readers = _readerService.GetReaders();
        }
    }
}
