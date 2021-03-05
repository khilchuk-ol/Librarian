using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class GenreRepository<TIdentity> : Repository<Genre, TIdentity>, IGenreRepository<TIdentity>
    {
        public GenreRepository(DbContext context) : base(context) { }

        public override IEnumerable<Genre> FindAll()
        {
            return _context.Set<Genre>().Include(g => g.Books).ToList();
        }

        public override Genre Find(int id)
        {
            return _context.Set<Genre>().Where(g => g.Id == id)
                                        .Include(g => g.Books)
                                        .FirstOrDefault();
        }
    }
}
