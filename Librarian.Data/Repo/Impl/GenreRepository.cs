using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class GenreRepository : Repository<Genre, int>, IGenreRepository<int>
    {
        public GenreRepository(DbContext context) : base(context) { } 
    }
}
