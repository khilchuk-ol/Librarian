using Librarian.Data.Models;
using Librarian.Data.Strategies;
using Librarian.Data.Strategies.Abstract;
using Librarian.Data.Strategies.Impl;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Factories.Impl
{
    public class FindReadersStrategyFactory : FindStrategyFactory<Reader, FindReadersType>
    {
        private readonly Dictionary<FindReadersType, FindReadersStrategy> _strategies = new Dictionary<FindReadersType, FindReadersStrategy>()
        {
            { FindReadersType.ByName, new FindReadersByNameStrategy() },
            { FindReadersType.ByTicket, new FindReadersByTicketStrategy() }
        };

        public override IFindStrategy<Reader> Create(FindReadersType type) => _strategies[type];
    }
}
