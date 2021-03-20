using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IBookService
    {
        IEnumerable<Book> FindBooksByTitle(string title);
        IEnumerable<Book> FindBooksByAuthor(int authorId);
        void LoadInfo(Book b);
        Book GetBookWithInfo(int id);
        IEnumerable<Book> GetBooks();
    }
}
