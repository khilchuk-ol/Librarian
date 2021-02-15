using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
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

        public IEnumerable<Reader> FindReadersByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            var str = FindStrategyFactory<Reader, string>.Instance.Create<Reader, string>(FindType.ReaderByName);

            return Repository.Find(str, query).ToHashSet();
        }

        public Reader FindReaderByTicket(int number) 
        {
            var str = FindStrategyFactory<Reader, int>.Instance.Create<Reader, int>(FindType.ReaderByTicket);

            return Repository.Find(str, number).FirstOrDefault();
        }
    }
}
