using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IBookRepository : IRepository<Book, int>
    {
        IEnumerable<Book> FindBooksByTitle(string title);
        IEnumerable<Book> FindBooksByAuthor(Author a);
    }
}
