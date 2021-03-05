using JetBrains.Annotations;
using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using Librarian.Domain.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Impl
{
    public class AuthorService : IAuthorService
    {
        public IAuthorRepository Repository { get; }
        public FindStrategyFactory<Author, FindAuthorsType> Factory { get; }

        public AuthorService([NotNull]IAuthorRepository repo, [NotNull]FindStrategyFactory<Author, FindAuthorsType> fact)
        {
            Repository = repo;
            Factory = fact;
        }

        public IEnumerable<Author> FindAuthorsByName([NotNull]string query)
        {
            var strategy = Factory.Create(FindAuthorsType.ByName);

            return strategy.Find(query);
        }

    }
}
