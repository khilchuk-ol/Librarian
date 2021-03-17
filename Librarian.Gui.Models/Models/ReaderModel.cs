using Librarian.Gui.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Librarian.Gui.Models
{
    public class ReaderModel : BaseModel
    {
        #region fields
        private int _id;
        private int _ticketNumber;
        private string _name;
        private string _surname;
        private string _parentname;
        private string _passport;
        private string _phone;
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

        public int TicketNumber
        {
            get { return _ticketNumber; }
            set
            {
                if (value != _ticketNumber)
                {
                    _ticketNumber = value;
                    OnPropertyChanged(nameof(TicketNumber));
                }
            }
        }

        [Required(ErrorMessage = "Reader's name must be specified")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }
        [Required(ErrorMessage = "Reader's surname must be specified")]
        public string Surname
        {
            get { return _surname; }
            set
            {
                if (value != _surname)
                {
                    _surname = value;
                    OnPropertyChanged(nameof(Surname));
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }
        public string Parentname
        {
            get { return _parentname; }
            set
            {
                if (value != _parentname)
                {
                    _parentname = value;
                    OnPropertyChanged(nameof(Parentname));
                    OnPropertyChanged(nameof(Fullname));
                }
            }
        }

        public string Passport
        {
            get { return _passport; }
            set
            {
                if (value != _passport)
                {
                    _passport = value;
                    OnPropertyChanged(nameof(Passport));
                }
            }
        }
        [Required(ErrorMessage = "Reader's phone number must be specified")]
        [RegularExpression(@"\(?\d{3}\)?-? *\d{3}-? *-?\d{4}", ErrorMessage = "Not valid phone number")]
        public string Phone
        {
            get { return _phone; }
            set
            {
                if (value != _phone)
                {
                    _phone = value;
                    OnPropertyChanged(nameof(Phone));
                }
            }
        }

        public string Fullname => string.Join(" ", new[] { _name, _surname, _parentname });
        #endregion
    }
}
