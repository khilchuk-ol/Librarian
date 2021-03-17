using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Abstract
{
    public abstract class FindAuthorsStrategy : IFindStrategy<Author>
    {
        public abstract IEnumerable<Author> Find(object criterion);
    }
}
