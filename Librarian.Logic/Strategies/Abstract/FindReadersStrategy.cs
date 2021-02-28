using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Abstract
{
    public abstract class FindReadersStrategy : IFindStrategy<Reader>
    {
        public abstract IEnumerable<Reader> Find(object criterion);
    }
}
