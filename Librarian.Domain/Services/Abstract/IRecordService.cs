using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IRecordService
    {
        void LoadInfo(Record r);
        Record GetRecordWithInfo(int id);
        IEnumerable<Record> GetRecords();
    }
}
