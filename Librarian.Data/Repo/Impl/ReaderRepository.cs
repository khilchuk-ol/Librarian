using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository<TIdentity> : Repository<Reader, TIdentity>, IReaderRepository<TIdentity>
    {
        public ReaderRepository(DbContext context) : base(context) { }

        public override IEnumerable<Reader> FindAll()
        {
            return _context.Set<Reader>().Include(r => r.Records.Select(rc => rc.Book)).ToList();
        }

        public override Reader Find(int id)
        {
            return _context.Set<Reader>().Where(r => r.Id == id)
                                         .Include(r => r.Records.Select(rc => rc.Book))
                                         .FirstOrDefault();
        }
    }
}
