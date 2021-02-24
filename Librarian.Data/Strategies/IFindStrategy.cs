using System.Linq;

namespace Librarian.Data.Strategies
{
    public interface IFindStrategy<TElement, TCriterion>
    { 
        IQueryable<TElement> Find(IQueryable<TElement> elements, TCriterion criterion);
    }
}
