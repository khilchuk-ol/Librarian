using Librarian.Data.Strategies;
using Librarian.Data.Strategies.TypesEnum;

namespace Librarian.Data.Factories
{
    public interface IFindStrategyFactory
    {
        IFindStrategy<TElement, TCriterion> Create<TElement, TCriterion>(FindType type);
    }
}
