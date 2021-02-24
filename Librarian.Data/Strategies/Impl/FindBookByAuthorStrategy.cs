using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindBookByAuthorStrategy : FindBookStrategy<Author>
    {
        public override IQueryable<Book> Find(IQueryable<Book> elements, Author criterion)
        {
            return elements.Where(b => b.Authors.Select(a => a.Id).Contains(criterion.Id));
        }
    }
}
