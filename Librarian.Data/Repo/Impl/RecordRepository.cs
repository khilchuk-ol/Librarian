using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class RecordRepository : Repository<Record, int>, IRecordRepository
    {
        public RecordRepository(DbContext context) : base(context) { }

        public IEnumerable<Record> FindIncludeAllWithInfo()
        {
            return _context.Set<Record>().Include(r => r.Book)
                                         .Include(r => r.Reader)
                                         .ToList();
        }

        public IEnumerable<Record> FindAllWithInfo()
        {

            var res = from record in _context.Set<Record>()
                      join book in _context.Set<Book>()
                          on record.BookId equals book.Id
                      join reader in _context.Set<Reader>()
                          on record.ReaderId equals reader.Id
                      select new 
                      {
                          Record = record,
                          Book = book,
                          Reader = reader
                      };

            return res.ToList().Select(r => new Record()
            {
                Id = r.Record.Id,
                BorrowDate = r.Record.BorrowDate,
                ReturnDate = r.Record.ReturnDate,
                BookId = r.Record.BookId,
                Book = r.Book,
                ReaderId = r.Record.ReaderId,
                Reader = r.Reader
            });
        }

        public Record FindWithInfo(int id)
        {
            var res = (from record in _context.Set<Record>()
                      where record.Id == id
                      join book in _context.Set<Book>()
                          on record.BookId equals book.Id
                      join reader in _context.Set<Reader>()
                          on record.ReaderId equals reader.Id
                      select new 
                      {
                          Record = record,
                          Reader = reader,
                          Book = book
                      }).ToList();

            return res.Select(tmp => new Record()
            {
                Id = tmp.Record.Id,
                BookId = tmp.Record.BookId,
                Book = tmp.Book,
                ReaderId = tmp.Record.ReaderId,
                Reader = tmp.Reader,
                ReturnDate = tmp.Record.ReturnDate,
                BorrowDate = tmp.Record.BorrowDate
            }).FirstOrDefault();
        }

        public Record FindIncludeWithInfo(int id)
        {
            return _context.Set<Record>().Where(r => r.Id == id)
                                        .Include(r => r.Book)
                                        .Include(r => r.Reader)
                                        .FirstOrDefault();
        }

        public IEnumerable<Record> GetActive(int readerId)
        {
            return _context.Set<Record>().Where(r => r.ReaderId == readerId && r.ReturnDate == null).ToList();
        }

        public IEnumerable<Record> GetPast(int readerId)
        {
            return _context.Set<Record>().Where(r => r.ReaderId == readerId && r.ReturnDate != null).ToList();
        }
    }
}
