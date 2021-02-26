using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindBooksStrategy : IFindStrategy<Book>
    {
        public abstract IEnumerable<Book> Find(IEnumerable<Book> elements, object criterion);
    }
}
