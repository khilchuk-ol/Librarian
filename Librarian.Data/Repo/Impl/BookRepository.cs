using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Impl
{
    public class BookRepository : IBookRepository
    {
        public IEnumerable<Book> FindAll()
        {
            return DataBaseImitation.DBBooks;
        }
    }
}
