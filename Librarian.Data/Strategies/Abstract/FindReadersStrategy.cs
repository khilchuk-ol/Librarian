using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindReadersStrategy : IFindStrategy<Reader>
    {
        public abstract IEnumerable<Reader> Find(IEnumerable<Reader> elements, object criterion);
    }
}
