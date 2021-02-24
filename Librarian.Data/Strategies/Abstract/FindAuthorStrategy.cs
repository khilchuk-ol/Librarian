using Librarian.Data.Models;
using System.Linq;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindAuthorStrategy<TCriterion> : IFindStrategy<Author, TCriterion>
    {
        public abstract IQueryable<Author> Find(IQueryable<Author> elements, TCriterion criterion);
    }
}
