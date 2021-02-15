using System;

namespace Librarian.Data.Strategies.Impl
{
    public class FindStrategy<TElement, TCriterion> : IFindStrategy<TElement, TCriterion>
    {
        private readonly Func<TElement, TCriterion, bool> _filter;

        public FindStrategy(Func<TElement, TCriterion, bool> filter)
        {
            _filter = filter ?? throw new ArgumentException("Bad argument for filter");
        }

        public bool IsMatch(TElement element, TCriterion criterion) => _filter(element, criterion);
    }
}
