using System;

namespace Librarian.Data.Strategies.Impl
{
    public class FindStrategy<TElement, TCriterion> : IFindStrategy<TElement, TCriterion>
    {
        private Func<TElement, TCriterion, bool> filter;

        public FindStrategy(Func<TElement, TCriterion, bool> filterFunc)
        {
            if (filter == null)
                throw new ArgumentException("Bad argument for filter");

            filter = filterFunc;
        }

        public bool IsMatch(TElement element, TCriterion criterion)
        {
            return filter(element, criterion);
        }
    }
}
