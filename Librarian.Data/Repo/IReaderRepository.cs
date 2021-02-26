using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IReaderRepository
    {
        IEnumerable<Reader> FindAll();
    }
}
