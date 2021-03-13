using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        IEnumerable<Author> FindAuthorsByName(string name);
        IEnumerable<Author> FindAuthorsByNameWithInfo(string name);
        IEnumerable<Author> FindIncludeAllWithInfo();
        IEnumerable<Author> FindAllWithInfo();
        Author FindWithInfo(int id);
    }
}
