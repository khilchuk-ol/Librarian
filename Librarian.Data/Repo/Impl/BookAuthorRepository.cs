using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class BookAuthorRepository : Repository<BookAuthor, int>, IBookAuthorRepository
    {
        public BookAuthorRepository(DbContext context) : base(context) { }
    }
}
