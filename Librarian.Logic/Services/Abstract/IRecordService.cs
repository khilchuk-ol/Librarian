using Librarian.Domain.Models.Core;

namespace Librarian.Domain.Services.Abstract
{
    public interface IRecordService
    {
        void LoadInfo(Record r);
    }
}
