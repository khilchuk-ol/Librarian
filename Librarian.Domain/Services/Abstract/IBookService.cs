using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> FindBooksByTitle(string title, int offset = 0, int amount = -1);
        IEnumerable<Book> FindBooksByAuthor(int authorId, int offset = 0, int amount = -1);
        void LoadInfo(Book b);
        Book GetBookWithInfo(int id);
        IEnumerable<Book> GetBooks();
        IEnumerable<Book> GetPage(int offset, int amount);
    }
}
