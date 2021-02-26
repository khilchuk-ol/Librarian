using Librarian.Data.Models;
using Librarian.Data.Strategies;
using Librarian.Data.Strategies.Abstract;
using Librarian.Data.Strategies.Impl;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Factories.Impl
{
    public class FindBooksStrategyFactory : FindStrategyFactory<Book, FindBooksType>
    {
        private readonly Dictionary<FindBooksType, FindBooksStrategy> _strategies = new Dictionary<FindBooksType, FindBooksStrategy>()
        {
            { FindBooksType.ByAuthor, new FindBooksByAuthorStrategy() },
            { FindBooksType.ByTitle, new FindBooksByTitleStrategy() }
        };

        public override IFindStrategy<Book> Create(FindBooksType type) => _strategies[type];
    }
}
