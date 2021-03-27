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
        IEnumerable<Reader> FindReadersByName(string name, int offset = 0, int amount = -1);
        IEnumerable<Reader> FindReadersByTicket(int ticketNumber, int offset = 0, int amount = -1);
        IEnumerable<Reader> FindReadersByNameWithInfo(string name, int offset = 0, int amount = -1);
        IEnumerable<Reader> FindReadersByTicketWithInfo(int ticketNumber, int offset = 0, int amount = -1);
    }
}
