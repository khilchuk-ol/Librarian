using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindAuthorsStrategy : IFindStrategy<Author>
    {
        public abstract IEnumerable<Author> Find(IEnumerable<Author> elements, object criterion);
    }
}
