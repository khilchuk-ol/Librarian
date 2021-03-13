using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class GenreBookRepository : Repository<GenreBook, int>, IGenreBookRepository
    {
        public GenreBookRepository(DbContext context) : base(context) { }
    }
}
