using Librarian.Gui.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Librarian.Gui.Models
{
    public class AuthorModel : BaseModel
    {
        #region fields
        private int _id;
        private string _name;
        private string _surname;
        private string _parentname;
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

        [Required(ErrorMessage = "Author's name must be specified")]
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
        [Required(ErrorMessage = "Author's name must be specified")]
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

        public string Fullname => string.Join(" ", new[] { _name, _surname, _parentname });
        #endregion
    }
}
