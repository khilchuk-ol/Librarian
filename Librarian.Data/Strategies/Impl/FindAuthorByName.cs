using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindAuthorByName : FindAuthorStrategy<string>
    {
        public override IQueryable<Author> Find(IQueryable<Author> elements, string criterion)
        {
            return elements.Where(a => a.Fullname.ToLower().Contains(criterion.Trim().ToLower()));
        }
    }
}
