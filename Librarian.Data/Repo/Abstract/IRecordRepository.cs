using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IRecordRepository : IRepository<Record, int>
    {
        IEnumerable<Record> FindIncludeAllWithInfo();
        Record FindIncludeWithInfo(int id);
        IEnumerable<Record> FindAllWithInfo();
        Record FindWithInfo(int id);
    }
}
