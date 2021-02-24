using Librarian.Data.Models;
using System.Linq;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindBookStrategy<TCriterion> : IFindStrategy<Book, TCriterion>
    {
        public abstract IQueryable<Book> Find(IQueryable<Book> elements, TCriterion criterion);
    }
}
