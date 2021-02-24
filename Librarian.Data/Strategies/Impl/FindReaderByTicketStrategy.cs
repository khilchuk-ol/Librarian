using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindReaderByTicketStrategy : FindReaderStrategy<int>
    {
        public override IQueryable<Reader> Find(IQueryable<Reader> elements, int criterion)
        {
            return elements.Where(r => r.TicketNumber == criterion);
        }
    }
}
