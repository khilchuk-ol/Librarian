using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IBookRepository
    {
        IEnumerable<Book> FindAll();
    }
}
