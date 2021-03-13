using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class GenreRepository : Repository<Genre, int>, IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context) { }

        public IEnumerable<Genre> FindIncludeAllWithInfo()
        {
            return _context.Set<Genre>().Include(g => g.Books).ToList();
        }

        public Genre FindIncludeWithInfo(int id)
        {
            return _context.Set<Genre>().Where(g => g.Id == id)
                                        .Include(g => g.Books)
                                        .FirstOrDefault();
        }

        public IEnumerable<Genre> FindAllWithInfo()
        {
            var res = (from genre in _context.Set<Genre>()
                      join bg in _context.Set<GenreBook>()
                          on genre.Id equals bg.GenreId
                      join book in _context.Set<Book>()
                          on bg.BookId equals book.Id
                          into books
                      orderby genre.Name
                      select new { Genre = genre, Books = books })
                      .ToList();

            return res.Select(tmp => new Genre()
            {
                Id = tmp.Genre.Id,
                Name = tmp.Genre.Name,
                Books = tmp.Books.ToList()
            });
        }

        public Genre FindWithInfo(int id)
        {
            var res = (from genre in _context.Set<Genre>()
                       where genre.Id == id
                       join bg in _context.Set<GenreBook>()
                           on genre.Id equals bg.GenreId
                       join book in _context.Set<Book>()
                           on bg.BookId equals book.Id
                           into books
                       orderby genre.Name
                       select new { Genre = genre, Books = books })
                      .ToList();

            return res.Select(tmp => new Genre()
            {
                Id = tmp.Genre.Id,
                Name = tmp.Genre.Name,
                Books = tmp.Books.ToList()
            }).FirstOrDefault();
        }
    }
}
