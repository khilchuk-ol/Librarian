using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IAuthorRepository : IRepository<Author, int>
    {
        IEnumerable<Author> FindAuthorsByName(string name);
    }
}
