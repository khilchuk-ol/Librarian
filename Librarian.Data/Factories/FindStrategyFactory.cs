using Librarian.Data.Strategies;

namespace Librarian.Data.Factories
{
    public abstract class FindStrategyFactory<TElement, TFindType>
    {
        public abstract IFindStrategy<TElement> Create(TFindType type); 
    }
}
