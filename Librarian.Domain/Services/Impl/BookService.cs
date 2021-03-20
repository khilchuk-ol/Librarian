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
        public IBookRepository Repository { get; }
        public FindStrategyFactory<Book, FindBooksType> Factory { get; }

        public BookService([NotNull]IBookRepository repo, [NotNull]FindStrategyFactory<Book, FindBooksType> fact)
        {
            Repository = repo;
            Factory = fact;
        }

        public IEnumerable<Book> FindBooksByTitle([NotNull]string title)
        {
            var strategy = Factory.Create(FindBooksType.ByTitle);

            return strategy.Find(title);
        }

        public IEnumerable<Book> FindBooksByAuthor(int authorId)
        {
            var strategy = Factory.Create(FindBooksType.ByAuthor);

            return strategy.Find(authorId);
        }

        public void LoadInfo(Book b)
        {
            var tmp = Repository.FindWithInfo(b.Id);
            b.Genres = tmp.Genres;
            b.Authors = tmp.Authors;
        }

        public Book GetBookWithInfo(int id)
        {
            return Repository.FindWithInfo(id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return Repository.FindAll();
        }
    }
}
