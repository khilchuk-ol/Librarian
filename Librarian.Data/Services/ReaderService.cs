using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Services
{
    public class ReaderService
    {
        public IReaderRepository Repository { get; }
        public FindReadersStrategyFactory Factory { get; }

        public ReaderService([NotNull]IReaderRepository repo, [NotNull]FindReadersStrategyFactory factory)
        {
            Repository = repo;
            Factory = factory;
        }

        public IEnumerable<Reader> FindReadersByName(string query)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            var strategy = Factory.Create(FindReadersType.ByName);

            return strategy.Find(Repository.FindAll(), query);
        }

        public IEnumerable<Reader> FindReaderByTicket(int number) 
        {
            if(number < 0)
            {
                return null;
            }

            var strategy = Factory.Create(FindReadersType.ByTicket);

            return strategy.Find(Repository.FindAll(), number);
        }
    }
}
