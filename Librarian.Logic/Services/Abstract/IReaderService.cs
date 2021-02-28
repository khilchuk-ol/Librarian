using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IReaderService
    {
        IEnumerable<Reader> FindReadersByName(string query);
        IEnumerable<Reader> FindReaderByTicket(int number);
    }
}
