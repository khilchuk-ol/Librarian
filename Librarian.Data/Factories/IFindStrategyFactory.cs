using Librarian.Data.Strategies;
using Librarian.Data.Strategies.TypesEnum;

namespace Librarian.Data.Factories
{
    public interface IFindStrategyFactory<TElement, TCriterion>
    {
        IFindStrategy<TElement, TCriterion> Create<TElement, TCriterion>(FindType type);
    }
}
