using Librarian.Data.Models;
using Librarian.Data.Strategies;
using Librarian.Data.Strategies.Abstract;
using Librarian.Data.Strategies.Impl;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Factories.Impl
{
    public class FindAuthorsStrategyFactory : FindStrategyFactory<Author, FindAuthorsType>
    {
        private readonly Dictionary<FindAuthorsType, FindAuthorsStrategy> _strategies = new Dictionary<FindAuthorsType, FindAuthorsStrategy>()
        {
            { FindAuthorsType.ByName, new FindAuthorsByNameStrategy() }
        };

        public override IFindStrategy<Author> Create(FindAuthorsType type) => _strategies[type];
    }
}
