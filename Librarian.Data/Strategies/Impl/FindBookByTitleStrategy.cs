using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindBookByTitleStrategy : FindBookStrategy<string>
    {
        public override IQueryable<Book> Find(IQueryable<Book> elements, string criterion)
        {
            return elements.Where(b => b.Title.ToUpperInvariant().Contains(criterion.Trim().ToUpperInvariant()));
        }
    }
}
