using JetBrains.Annotations;
using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using Librarian.Domain.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Impl
{
    public class ReaderService : IReaderService
    {
        public IReaderRepository Repository { get; }
        public FindStrategyFactory<Reader, FindReadersType> Factory { get; }

        public ReaderService([NotNull]IReaderRepository repo, [NotNull]FindStrategyFactory<Reader, FindReadersType> factory)
        {
            Repository = repo;
            Factory = factory;
        }

        public IEnumerable<Reader> FindReadersByName([NotNull]string query)
        {
            var strategy = Factory.Create(FindReadersType.ByName);

            return strategy.Find(query);
        }

        public IEnumerable<Reader> FindReaderByTicket(int number) 
        {
            if(number < 0)
            {
                return null;
            }

            var strategy = Factory.Create(FindReadersType.ByTicket);

            return strategy.Find(number);
        }

        public void LoadInfo(Reader r)
        {
            r.Records = Repository.FindWithInfo(r.Id).Records;
        }

        public Reader GetReaderWithInfo(int id)
        {
            return Repository.FindWithInfo(id);
        }
    }
}
