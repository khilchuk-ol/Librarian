using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Abstract
{
    public interface IFindStrategy<TElement>
    { 
        IEnumerable<TElement> Find(object criterion);
    }
}
