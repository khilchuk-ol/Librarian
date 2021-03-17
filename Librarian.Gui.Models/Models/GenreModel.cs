using Librarian.Gui.Models.Abstract;
using System.ComponentModel.DataAnnotations;

namespace Librarian.Gui.Models
{
    public class GenreModel : BaseModel
    {
        #region fields
        private int _id;
        private string _name;
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

        [Required(ErrorMessage = "Genre's name must be specified")]
        public string Name
        {
            get { return _name; }
            set
            {
                if (value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }

        #endregion
    }
}
