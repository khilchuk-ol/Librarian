using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository : IReaderRepository
    {
        public ICollection<Reader> FindAll()
        {
            return DataBaseImitation.DBReaders;
        }
    }
}
