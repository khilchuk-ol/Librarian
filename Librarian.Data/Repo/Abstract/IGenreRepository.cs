using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IGenreRepository : IRepository<Genre, int>
    {
        IEnumerable<Genre> FindIncludeAllWithInfo();
        IEnumerable<Genre> FindAllWithInfo();
        Genre FindIncludeWithInfo(int id);
        Genre FindWithInfo(int id);
    }
}
