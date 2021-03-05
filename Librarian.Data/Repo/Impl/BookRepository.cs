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

        public override IEnumerable<Book> FindAll()
        {
            return _context.Set<Book>().Include(b => b.Genres)
                                       .Include(b => b.Authors)
                                       .ToList();
        }
        
        public override Book Find(int id)
        {
            return _context.Set<Book>().Where(b => b.Id == id)
                                       .Include(b => b.Authors)
                                       .Include(b => b.Genres)
                                       .FirstOrDefault();
        }
    }
}
