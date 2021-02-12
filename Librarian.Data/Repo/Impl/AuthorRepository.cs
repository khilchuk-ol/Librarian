using Librarian.Data.Models;
using System.Collections.Generic;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : IAuthorRepository
    {
        public ICollection<Author> FindAll()
        {
            return DataBaseImitation.DBAuthors;
        }
    }
}
