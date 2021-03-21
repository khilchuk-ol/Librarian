using Librarian.Gui.Models;
using System.Collections.ObjectModel;

namespace Librarian.Gui.Services.Abstract
{
    public interface IRecordModelService
    {
        RecordModel GetRecordWithInfo(int id);
        ObservableCollection<RecordModel> GetRecords();
        ObservableCollection<RecordModel> GetActive(int readerId);
        ObservableCollection<RecordModel> GetPast(int readerId);
    }
}
