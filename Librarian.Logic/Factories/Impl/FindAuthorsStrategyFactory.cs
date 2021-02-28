using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using Librarian.Domain.Strategies.Impl;
using Librarian.Domain.Strategies.TypesEnum;
using Librarian.Logic.Exceptions;

namespace Librarian.Domain.Factories.Impl
{
    public class FindAuthorsStrategyFactory : FindStrategyFactory<Author, FindAuthorsType>
    {
        protected IAuthorRepository<int> _repo;

        public FindAuthorsStrategyFactory(IAuthorRepository<int> repo) => _repo = repo;

        public override IFindStrategy<Author> Create(FindAuthorsType type)
        {
            if (type == FindAuthorsType.ByName)
            {
                return new FindAuthorsByNameStrategy(_repo);
            }
            
            throw new InvalidStrategyFindTypeException<Author, FindAuthorsType>(type, this);
        }
    }
}
