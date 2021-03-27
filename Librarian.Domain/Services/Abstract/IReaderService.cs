using Librarian.Domain.Models.Core;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Abstract
{
    public interface IReaderService
    {
        IEnumerable<Reader> FindReadersByName(string query, int offset = 0, int amount = -1);
        IEnumerable<Reader> FindReaderByTicket(int number, int offset = 0, int amount = -1);
        void LoadInfo(Reader r);
        Reader GetReaderWithInfo(int id);
        IEnumerable<Reader> GetReaders();
        IEnumerable<Reader> GetPage(int offset, int amount);
    }
}
