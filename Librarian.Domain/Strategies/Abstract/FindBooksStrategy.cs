using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Abstract
{
    public abstract class FindBooksStrategy : IFindStrategy<Book>
    {
        public abstract IEnumerable<Book> Find(object criterion);
    }
}
