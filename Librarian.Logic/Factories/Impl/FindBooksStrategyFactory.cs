using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using Librarian.Domain.Strategies.Impl;
using Librarian.Domain.Strategies.TypesEnum;
using Librarian.Logic.Exceptions;

namespace Librarian.Domain.Factories.Impl
{
    public class FindBooksStrategyFactory : FindStrategyFactory<Book, FindBooksType>
    {
        protected IBookRepository _repo;

        public FindBooksStrategyFactory(IBookRepository repo) => _repo = repo;

        public override IFindStrategy<Book> Create(FindBooksType type)
        {
            if(type == FindBooksType.ByAuthor)
            {
                return new FindBooksByAuthorStrategy(_repo);
            }

            if(type == FindBooksType.ByTitle)
            {
                return new FindBooksByTitleStrategy(_repo);
            }

            throw new InvalidStrategyFindTypeException<Book, FindBooksType>(type, this);
        }
    }
}
