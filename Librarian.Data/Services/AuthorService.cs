using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Services
{
    public class AuthorService
    {
        public IAuthorRepository Repository { get; }

        public AuthorService([NotNull]IAuthorRepository repo)
        {
            Repository = repo;
        }

        public IEnumerable<Author> FindAuthorsByName(string query = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            var str = FindStrategyFactory<Author, string>.Instance.Create<Author, string>(FindType.AuthorByName);

            return Repository.Find(str, query).ToHashSet(); 
        }

    }
}
