using Librarian.Gui.ViewModels.Abstract;

namespace Librarian.Gui.ViewModels
{
    public class HomeViewModel : ViewModel
    {
        #region fields
        private string _msg;
        #endregion

        #region properties
        public string Message
        {
            get => _msg;
            set
            {
                if(value != _msg)
                {
                    _msg = value;
                    OnPropertyChanged(nameof(Message));
                }
            }
        }
        #endregion

        public HomeViewModel()
        {
            Message = "Librarian - your personal library manager";
            Name = "Home";
        }
    }
}
