using JetBrains.Annotations;
using Librarian.Data.Factories.Impl;
using Librarian.Data.Models;
using Librarian.Data.Repo;
using Librarian.Data.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Data.Services
{
    public class BookService
    {
        public IBookRepository Repository { get; }
        public FindBooksStrategyFactory Factory { get; }

        public BookService([NotNull]IBookRepository repo, [NotNull]FindBooksStrategyFactory fact)
        {
            Repository = repo;
            Factory = fact;
        }

        public IEnumerable<Book> FindBooksByTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                return null;
            }

            var strategy = Factory.Create(FindBooksType.ByTitle);

            return strategy.Find(Repository.FindAll(), title);
        }

        public IEnumerable<Book> FindBooksByAuthor(Author a)
        {
            if(a == null)
            {
                return null;
            }

            var strategy = Factory.Create(FindBooksType.ByAuthor);

            return strategy.Find(Repository.FindAll(), a);
        }
    }
}
