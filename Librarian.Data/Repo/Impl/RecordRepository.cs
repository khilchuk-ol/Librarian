using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class RecordRepository : Repository<Record, int>, IRecordRepository<int>
    {
        public RecordRepository(DbContext context) : base(context) { }
    }
}
