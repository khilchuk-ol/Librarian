using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IReaderRepository : IRepository<Reader, int>
    {
        IEnumerable<Reader> FindAllWithInfo();
        IEnumerable<Reader> FindIncludeAllWithInfo();
        Reader FindWithInfo(int id);
        Reader FindIncludeWithInfo(int id);
        IEnumerable<Reader> FindReadersByName(string name);
        IEnumerable<Reader> FindReadersByTicket(int ticketNumber);
        IEnumerable<Reader> FindReadersByNameWithInfo(string name);
        IEnumerable<Reader> FindReadersByTicketWithInfo(int ticketNumber);
    }
}
