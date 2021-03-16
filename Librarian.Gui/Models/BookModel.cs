using Librarian.Gui.Models.Abstract;
using System;

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
        [Required]
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
        public int PageCount { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public bool IsBorrowed { get; set; }

        [NotMapped]
        public List<Author> Authors { get; set; } = new List<Author>();
        [NotMapped]
        public List<Genre> Genres { get; set; } = new List<Genre>();
        #endregion
    }
}
