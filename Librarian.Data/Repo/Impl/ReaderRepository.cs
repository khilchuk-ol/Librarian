using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository : Repository<Reader, int>, IReaderRepository<int>
    {
        public ReaderRepository(DbContext context) : base(context) { }

        public override IEnumerable<Reader> FindAll()
        {
            return _context.Set<Reader>().Include(r => r.Records.Select(rc => rc.Book)).ToList();
        }
    }
}
