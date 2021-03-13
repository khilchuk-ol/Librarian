using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IBookRepository : IRepository<Book, int>
    {
        IEnumerable<Book> FindBooksByTitle(string title);
        IEnumerable<Book> FindBooksByAuthor(Author a);
        IEnumerable<Book> FindBooksByTitleWithInfo(string title);
        IEnumerable<Book> FindBooksByAuthorWithInfo(Author a);
        IEnumerable<Book> FindAllWithInfo();
        IEnumerable<Book> FindIncludeAllWithInfo();
        Book FindWithInfo(int id);
        Book FindIncludeWithInfo(int id);
    }
}
