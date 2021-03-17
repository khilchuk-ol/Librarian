using Librarian.Gui.Models.Abstract;
using System;
using System.ComponentModel.DataAnnotations;

namespace Librarian.Gui.Models
{
    public class BookModel : BaseModel
    {
        #region fields
        private int _id;
        private int _number;
        private string _title;
        private int _pageCount;
        private DateTime? _releaseDate;
        private bool _isBorrowed;
        private string _genres;
        private string _authors;
        #endregion

        #region properties
        public int Id
        {
            get { return _id; }
            set
            {
                if(value != _id)
                {
                    _id = value;
                    OnPropertyChanged(nameof(Id));
                }
            }
        }

        [Range(0, int.MaxValue, ErrorMessage = "Librarian number of the book must be greater than 0")]
        public int Number
        {
            get { return _number; }
            set
            {
                if(value != _number)
                {
                    _number = value;
                    OnPropertyChanged(nameof(Number));
                }
            }
        }
        [Required(ErrorMessage = "Book's title must be specified")]
        public string Title
        {
            get { return _title; }
            set
            {
                if(value != _title)
                {
                    _title = value;
                    OnPropertyChanged(nameof(Title));
                }
            }
        }
        [Range(0, int.MaxValue, ErrorMessage = "amount of pages of the book must be greater than 0")]
        public int PageCount
        {
            get { return _pageCount; }
            set
            {
                if (value != _pageCount)
                {
                    _pageCount = value;
                    OnPropertyChanged(nameof(PageCount));
                }
            }
        }
        public DateTime? ReleaseDate
        {
            get { return _releaseDate; }
            set
            {
                if (value != _releaseDate)
                {
                    _releaseDate = value;
                    OnPropertyChanged(nameof(ReleaseDate));
                }
            }
        }

        public bool IsBorrowed
        {
            get { return _isBorrowed; }
            set
            {
                if (value != _isBorrowed)
                {
                    _isBorrowed = value;
                    OnPropertyChanged(nameof(IsBorrowed));
                }
            }
        }

        public string GenresStr
        {
            get { return _genres; }
            set
            {
                if(value != _genres)
                {
                    _genres = value;
                    OnPropertyChanged(nameof(GenresStr));
                }
            }
        }

        public string AuthorsStr
        {
            get { return _authors; }
            set
            {
                if (value != _authors)
                {
                    _authors = value;
                    OnPropertyChanged(nameof(AuthorsStr));
                }
            }
        }
        #endregion
    }
}
