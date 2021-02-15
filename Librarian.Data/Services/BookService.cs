using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
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

        public IEnumerable<Book> FindBooksByTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            var str = FindStrategyFactory<Book, string>.Instance.Create<Book, string>(FindType.BookByTitle);

            return Repository.Find(str, title).ToHashSet();
        }

        public IEnumerable<Book> FindBooksByAuthor(Author a)
        {
            if(a == null)
            {
                return null;
            }

            var str = FindStrategyFactory<Book, int>.Instance.Create<Book, int>(FindType.BookByAuthor);

            return Repository.Find(str, a.Id).ToHashSet();
        }
    }
}
