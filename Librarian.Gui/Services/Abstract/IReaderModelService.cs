using Librarian.Gui.Models;
using System.Collections.ObjectModel;

namespace Librarian.Gui.Services.Abstract
{
    public interface IReaderModelService
    {
        ObservableCollection<ReaderModel> FindReadersByName(string query);
        ObservableCollection<ReaderModel> FindReaderByTicket(int number);
        ReaderModel GetReaderWithInfo(int id);
        ObservableCollection<ReaderModel> GetReaders();
    }
}
