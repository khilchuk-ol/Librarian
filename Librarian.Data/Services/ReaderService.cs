using JetBrains.Annotations;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Services
{
    public class ReaderService
    {
        public IReaderRepository Repository { get; }

        public ReaderService([NotNull]IReaderRepository repo)
        {
            Repository = repo;
        }

        public ICollection<Reader> FindReadersByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            return Repository.FindAll().Where(r => r.Fullname.ToLower().Contains(query.Trim().ToLower())).ToHashSet();
        }

        public Reader FindReaderByTicket(int number)
        {
            return Repository.FindAll().Where(r => r.TicketNumber == number).FirstOrDefault();
        }
    }
}
