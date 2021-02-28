using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository<int>
    {
        public AuthorRepository(DbContext context) : base(context) { }
    }
}
