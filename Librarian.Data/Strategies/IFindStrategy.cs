using System.Collections.Generic;

namespace Librarian.Data.Strategies
{
    public interface IFindStrategy<TElement>
    { 
        IEnumerable<TElement> Find(IEnumerable<TElement> elements, object criterion);
    }
}
