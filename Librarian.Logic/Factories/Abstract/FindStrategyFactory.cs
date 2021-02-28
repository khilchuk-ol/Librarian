using Librarian.Domain.Strategies.Abstract;

namespace Librarian.Domain.Factories.Abstract
{
    public abstract class FindStrategyFactory<TElement, TFindType>
    {
        public abstract IFindStrategy<TElement> Create(TFindType type); 
    }
}
