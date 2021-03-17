using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using Librarian.Domain.Strategies.Impl;
using Librarian.Domain.Strategies.TypesEnum;
using Librarian.Logic.Exceptions;

namespace Librarian.Domain.Factories.Impl
{
    public class FindReadersStrategyFactory : FindStrategyFactory<Reader, FindReadersType>
    {
        protected IReaderRepository _repo;

        public FindReadersStrategyFactory(IReaderRepository repo) => _repo = repo;

        public override IFindStrategy<Reader> Create(FindReadersType type)
        {
            if(type == FindReadersType.ByName)
            {
                return new FindReadersByNameStrategy(_repo);
            }

            if(type == FindReadersType.ByTicket)
            {
                return new FindReadersByTicketStrategy(_repo);
            }

            throw new InvalidStrategyFindTypeException<Reader, FindReadersType>(type, this);
        }
    }
}
