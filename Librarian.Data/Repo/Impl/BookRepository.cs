using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Impl
{
    public class BookRepository : IBookRepository
    {
        public ICollection<Book> FindAll()
        {
            return DataBaseImitation.DBBooks;
        }
    }
}
