using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IReaderRepository : IRepository<Reader, int>
    {
        IEnumerable<Reader> FindReadersByName(string name);
        IEnumerable<Reader> FindReadersByTicket(int ticketNumber);
    }
}
