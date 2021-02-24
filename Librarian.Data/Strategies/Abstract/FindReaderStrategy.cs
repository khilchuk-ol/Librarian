using Librarian.Data.Models;
using System.Linq;

namespace Librarian.Data.Strategies.Abstract
{
    public abstract class FindReaderStrategy<TCriterion> : IFindStrategy<Reader, TCriterion>
    {
        public abstract IQueryable<Reader> Find(IQueryable<Reader> elements, TCriterion criterion);
    }
}
