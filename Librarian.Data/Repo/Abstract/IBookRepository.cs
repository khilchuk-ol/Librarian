using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IBookRepository : IRepository<Book, int>
    {
        IEnumerable<Book> FindBooksByTitle(string title, int offset = 0, int amount = -1);
        IEnumerable<Book> FindBooksByAuthor(int authorId, int offset = 0, int amount = -1);
        IEnumerable<Book> FindBooksByTitleWithInfo(string title, int offset = 0, int amount = -1);
        IEnumerable<Book> FindBooksByAuthorWithInfo(int authorId, int offset = 0, int amount = -1);
        IEnumerable<Book> FindAllWithInfo();
        IEnumerable<Book> FindIncludeAllWithInfo();
        Book FindWithInfo(int id);
        Book FindIncludeWithInfo(int id);
    }
}
