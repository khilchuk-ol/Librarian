using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository<int>
    {
        public AuthorRepository(DbContext context) : base(context) { }

        public override IEnumerable<Author> FindAll()
        {
            return _context.Set<Author>().Include(a => a.Books).ToList();
        }
    }
}
