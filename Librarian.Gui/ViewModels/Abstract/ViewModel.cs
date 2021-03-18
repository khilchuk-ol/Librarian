using Librarian.Gui.Models.Abstract;

namespace Librarian.Gui.ViewModels.Abstract
{
    public abstract class ViewModel : BaseModel
    {
        #region fields
        private string _name;
        #endregion

        #region properties
        public string Name
        {
            get => _name;
            set
            {
                if(value != _name)
                {
                    _name = value;
                    OnPropertyChanged(nameof(Name));
                }
            }
        }
        #endregion
    }
}
