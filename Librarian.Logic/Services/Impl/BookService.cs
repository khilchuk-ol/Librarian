using JetBrains.Annotations;
using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Factories.Abstract;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Services.Abstract;
using Librarian.Domain.Strategies.TypesEnum;
using System.Collections.Generic;

namespace Librarian.Domain.Services.Impl
{
    public class BookService : IBookService
    {
        public IBookRepository<int> Repository { get; }
        public FindStrategyFactory<Book, FindBooksType> Factory { get; }

        public BookService([NotNull]IBookRepository<int> repo, [NotNull]FindStrategyFactory<Book, FindBooksType> fact)
        {
            Repository = repo;
            Factory = fact;
        }

        public IEnumerable<Book> FindBooksByTitle([NotNull]string title)
        {
            var strategy = Factory.Create(FindBooksType.ByTitle);

            return strategy.Find(Repository.FindAll(), title);
        }

        public IEnumerable<Book> FindBooksByAuthor([NotNull]Author a)
        {
            var strategy = Factory.Create(FindBooksType.ByAuthor);

            return strategy.Find(Repository.FindAll(), a);
        }
    }
}
