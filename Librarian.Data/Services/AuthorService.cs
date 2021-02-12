using JetBrains.Annotations;
using Librarian.Data.Models;
using Librarian.Data.Repo;
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

        public ICollection<Author> FindAuthorsByName(string query = null)
        {
            if (string.IsNullOrWhiteSpace(query))
            {
                return null;
            }

            return Repository.FindAll().Where(a => a.Fullname.ToLower().Contains(query.Trim().ToLower())).ToHashSet(); 
        }
    }
}
