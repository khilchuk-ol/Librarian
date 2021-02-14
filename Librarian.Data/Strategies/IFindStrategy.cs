namespace Librarian.Data.Strategies
{
    public interface IFindStrategy<TElement, TCriterion>
    {
        bool IsMatch(TElement element, TCriterion criterion);
    }
}
