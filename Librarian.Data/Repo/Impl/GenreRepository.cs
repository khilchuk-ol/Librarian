using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class GenreRepository : Repository<Genre, int>, IGenreRepository<int>
    {
        public GenreRepository(DbContext context) : base(context) { }

        public override IEnumerable<Genre> FindAll()
        {
            return _context.Set<Genre>().Include(g => g.Books).ToList();
        }
    }
}
