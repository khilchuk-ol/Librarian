using JetBrains.Annotations;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Services
{
    public class BookService
    {
        public IBookRepository Repository { get; }

        public BookService([NotNull]IBookRepository repo)
        {
            Repository = repo;
        }

        public ICollection<Book> FindBooksByTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            return Repository.FindAll().Where(b => b.Title.ToLower().Contains(title.Trim().ToLower())).ToHashSet();
        }

        public ICollection<Book> FindBooksByAuthor(Author a)
        {
            if(a == null)
            {
                return null;
            }

            return Repository.FindAll().Where(b => b.Authors.Select(au => au.Id).ToList().Contains(a.Id)).ToHashSet();
        }
    }
}
