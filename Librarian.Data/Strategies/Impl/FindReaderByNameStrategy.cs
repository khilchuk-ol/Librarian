using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindReaderByNameStrategy : FindReaderStrategy<string>
    {
        public override IQueryable<Reader> Find(IQueryable<Reader> elements, string criterion)
        {
            return elements.Where(r => r.Fullname.ToUpperInvariant().Contains(criterion.Trim().ToUpperInvariant()));
        }
    }
}
