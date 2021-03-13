using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context) { }

        public IEnumerable<Author> FindAllWithInfo()
        {
            var r = (from a in _context.Set<Author>()
                     join ab in _context.Set<BookAuthor>()
                         on a.Id equals ab.AuthorId
                     join b in _context.Set<Book>()
                         on ab.BookId equals b.Id
                         into authorBooks
                     orderby a.Name, a.Surname, a.Parentname
                     select new { Author = a, Books = authorBooks })
                    .ToList();

            return r.Select(tmp => new Author()
            {
                Id = tmp.Author.Id,
                Name = tmp.Author.Name,
                Surname = tmp.Author.Surname,
                Parentname = tmp.Author.Parentname,
                Books = tmp.Books.ToList()
            });
        }

        public IEnumerable<Author> FindIncludeAllWithInfo()
        {
            return _context.Set<Author>().Include(a => a.Books).ToList();
        }

        public Author FindWithInfo(int id)
        {
            var r = (from a in _context.Set<Author>()
                     where a.Id == id
                     join ab in _context.Set<BookAuthor>()
                         on a.Id equals ab.AuthorId
                     join b in _context.Set<Book>()
                         on ab.BookId equals b.Id
                         into authorBooks
                     select new { Author = a, Books = authorBooks })
                    .ToList();

            return r.Select(tmp => new Author()
            {
                Id = tmp.Author.Id,
                Name = tmp.Author.Name,
                Surname = tmp.Author.Surname,
                Parentname = tmp.Author.Parentname,
                Books = tmp.Books.ToList()
            }).FirstOrDefault();
        }

        public IEnumerable<Author> FindAuthorsByName(string name)
        {
            return _context.Set<Author>().Where(a => (a.Name + " " + a.Surname + " " + a.Parentname).Contains(name))
                                         .ToList();
        }

        public IEnumerable<Author> FindAuthorsByNameWithInfo(string name)
        {
            var r = (from a in _context.Set<Author>()
                    where (a.Name + " " + a.Surname + " " + a.Parentname).Contains(name)
                     join ab in _context.Set<BookAuthor>()
                        on a.Id equals ab.AuthorId
                    join b in _context.Set<Book>()
                        on ab.BookId equals b.Id
                        into authorBooks
                     orderby a.Name, a.Surname, a.Parentname
                     select new { Author = a, Books = authorBooks })
                    .ToList();

            return r.Select(tmp => new Author()
            {
                Id = tmp.Author.Id,
                Name = tmp.Author.Name,
                Surname = tmp.Author.Surname,
                Parentname = tmp.Author.Parentname,
                Books = tmp.Books.ToList()
            });
        }
    }
}
