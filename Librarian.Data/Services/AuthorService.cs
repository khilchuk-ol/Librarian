using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Services
{
    public class AuthorService
    {
        public IAuthorRepository Repository { get; }
        public FindAuthorsStrategyFactory Factory { get; }

        public AuthorService([NotNull]IAuthorRepository repo, [NotNull]FindAuthorsStrategyFactory fact)
        {
            Repository = repo;
            Factory = fact;
        }

        public IEnumerable<Author> FindAuthorsByName(string query = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            var strategy = Factory.Create(FindAuthorsType.ByName);

            return strategy.Find(Repository.FindAll(), query);
        }

    }
}
