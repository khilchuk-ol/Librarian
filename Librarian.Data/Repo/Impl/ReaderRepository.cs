using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository : Repository<Reader, int>, IReaderRepository<int>
    {
        public ReaderRepository(DbContext context) : base(context) { }
    }
}
