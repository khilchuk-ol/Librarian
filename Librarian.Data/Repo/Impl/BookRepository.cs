using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class BookRepository : Repository<Book, int>, IBookRepository
    {
        public BookRepository(DbContext context) : base(context) { }

        public IEnumerable<Book> FindIncludeAllWithInfo()
        {
            return _context.Set<Book>().Include(b => b.Genres)
                                       .Include(b => b.Authors)
                                       .ToList();
        }
        
        public Book FindIncludeWithInfo(int id)
        {
            return _context.Set<Book>().Where(b => b.Id == id)
                                       .Include(b => b.Authors)
                                       .Include(b => b.Genres)
                                       .FirstOrDefault();
        }

        public IEnumerable<Book> FindAllWithInfo()
        {
            var res = (from book in _context.Set<Book>()
                      join ab in _context.Set<BookAuthor>()
                          on book.Id equals ab.BookId
                      join author in _context.Set<Author>()
                           on ab.AuthorId equals author.Id
                           into authors
                      join gb in _context.Set<GenreBook>()
                          on book.Id equals gb.BookId
                      join genre in _context.Set<Genre>()
                           on gb.GenreId equals genre.Id
                           into genres
                       orderby book.Title, book.ReleaseDate
                       select new { Book = book, Genres = genres, Authors = authors }).ToList();

            return res.Select(tmp => new Book()
            {
                Id = tmp.Book.Id,
                Title = tmp.Book.Title,
                ReleaseDate = tmp.Book.ReleaseDate,
                Number = tmp.Book.Number,
                PageCount = tmp.Book.PageCount,
                IsBorrowed = tmp.Book.IsBorrowed,
                Authors = tmp.Authors.ToList(),
                Genres = tmp.Genres.ToList()
            });
        }

        public Book FindWithInfo(int id)
        {
            var res = (from book in _context.Set<Book>()
                       where book.Id == id
                       join ab in _context.Set<BookAuthor>()
                           on book.Id equals ab.BookId
                       join author in _context.Set<Author>()
                            on ab.AuthorId equals author.Id
                            into authors
                       join gb in _context.Set<GenreBook>()
                           on book.Id equals gb.BookId
                       join genre in _context.Set<Genre>()
                            on gb.GenreId equals genre.Id
                            into genres
                       select new { Book = book, Genres = genres, Authors = authors }).ToList();

            return res.Select(tmp => new Book()
            {
                Id = tmp.Book.Id,
                Title = tmp.Book.Title,
                ReleaseDate = tmp.Book.ReleaseDate,
                Number = tmp.Book.Number,
                PageCount = tmp.Book.PageCount,
                IsBorrowed = tmp.Book.IsBorrowed,
                Authors = tmp.Authors.ToList(),
                Genres = tmp.Genres.ToList()
            }).FirstOrDefault();
        }

        public IEnumerable<Book> FindBooksByTitle(string title)
        {
            return _context.Set<Book>().Where(b => b.Title.Contains(title))
                                       .ToList();
        }

        public IEnumerable<Book> FindBooksByAuthor(Author a)
        {
            var ids =  _context.Set<BookAuthor>().Where(ba => ba.AuthorId == a.Id)
                                                 .Select(ba => ba.BookId);

            return _context.Set<Book>().Where(b => ids.Contains(b.Id)).ToList();
        }

        public IEnumerable<Book> FindBooksByTitleWithInfo(string title)
        {
            var res = (from book in _context.Set<Book>()
                       where book.Title.Contains(title)
                       join ab in _context.Set<BookAuthor>()
                           on book.Id equals ab.BookId
                       join author in _context.Set<Author>()
                            on ab.AuthorId equals author.Id
                            into authors
                       join gb in _context.Set<GenreBook>()
                           on book.Id equals gb.BookId
                       join genre in _context.Set<Genre>()
                            on gb.GenreId equals genre.Id
                            into genres
                       orderby book.Title, book.ReleaseDate
                       select new { Book = book, Genres = genres, Authors = authors }).ToList();

            return res.Select(tmp => new Book()
            {
                Id = tmp.Book.Id,
                Title = tmp.Book.Title,
                ReleaseDate = tmp.Book.ReleaseDate,
                Number = tmp.Book.Number,
                PageCount = tmp.Book.PageCount,
                IsBorrowed = tmp.Book.IsBorrowed,
                Authors = tmp.Authors.ToList(),
                Genres = tmp.Genres.ToList()
            });
        }

        public IEnumerable<Book> FindBooksByAuthorWithInfo(Author a)
        {
            var bookIds = from book in _context.Set<Book>()
                         join ab in _context.Set<BookAuthor>()
                             on book.Id equals ab.BookId
                         where ab.AuthorId == a.Id
                         select book.Id;

            var res = (from book in _context.Set<Book>()
                       where bookIds.Contains(book.Id)
                       join ab in _context.Set<BookAuthor>()
                           on book.Id equals ab.BookId
                       join author in _context.Set<Author>()
                            on ab.AuthorId equals author.Id
                            into authors
                       join gb in _context.Set<GenreBook>()
                           on book.Id equals gb.BookId
                       join genre in _context.Set<Genre>()
                            on gb.GenreId equals genre.Id
                            into genres
                       orderby book.Title, book.ReleaseDate
                       select new { Book = book, Genres = genres, Authors = authors }).ToList();

            return res.Select(tmp => new Book()
            {
                Id = tmp.Book.Id,
                Title = tmp.Book.Title,
                ReleaseDate = tmp.Book.ReleaseDate,
                Number = tmp.Book.Number,
                PageCount = tmp.Book.PageCount,
                IsBorrowed = tmp.Book.IsBorrowed,
                Authors = tmp.Authors.ToList(),
                Genres = tmp.Genres.ToList()
            });
        }
    }
}
