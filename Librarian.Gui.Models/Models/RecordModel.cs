using Librarian.Gui.Models.Abstract;
using System;

namespace Librarian.Gui.Models
{
    public class RecordModel : BaseModel
    {
        #region fields
        private int _id;
        private DateTime _borrowDate;
        private DateTime? _returnDate;
        private int _bookId;
        private string _bookTitle;
        private int _readerId;
        #endregion

        #region properties
        public int Id
        {
            get { return _id; }
            set
            {
                if (value != _id)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        public DateTime BorrowDate
        {
            get { return _borrowDate; }
            set
            {
                if (value != _borrowDate)
                {
                    _borrowDate = value;
                    OnPropertyChanged(nameof(BorrowDate));
                }
            }
        }

        public DateTime? ReturnDate
        {
            get { return _returnDate; }
            set
            {
                if (value != _returnDate)
                {
                    _returnDate = value;
                    OnPropertyChanged(nameof(ReturnDate));
                }
            }
        }

        public int BookId
        {
            get { return _bookId; }
            set
            {
                if (value != _bookId)
                {
                    _bookId = value;
                    OnPropertyChanged(nameof(BookId));
                }
            }
        }
        public string BookTitle
        {
            get { return _bookTitle; }
            set
            {
                if (value != _bookTitle)
                {
                    _bookTitle = value;
                    OnPropertyChanged(nameof(BookTitle));
                }
            }
        }
        public int ReaderId
        {
            get { return _readerId; }
            set
            {
                if (value != _readerId)
                {
                    _readerId = value;
                    OnPropertyChanged(nameof(ReaderId));
                }
            }
        }

        public TimeSpan DurationOfBorrow => (_returnDate ?? DateTime.Now) - _borrowDate;
        #endregion
    }
}
