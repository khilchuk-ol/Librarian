using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class RecordRepository : Repository<Record, int>, IRecordRepository<int>
    {
        public RecordRepository(DbContext context) : base(context) { }

        public override IEnumerable<Record> FindAll()
        {
            return _context.Set<Record>().Include(r => r.Book)
                                         .Include(r => r.Reader)
                                         .ToList();
        }

        public override Record Find(int id)
        {
            return _context.Set<Record>().Where(r => r.Id == id)
                                        .Include(r => r.Book)
                                        .Include(r => r.Reader)
                                        .FirstOrDefault();
        }
    }
}
