using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository : Repository<Reader, int>, IReaderRepository
    {
        public ReaderRepository(DbContext context) : base(context) { }

        public IEnumerable<Reader> FindIncludeAllWithInfo()
        {
            return _context.Set<Reader>().Include(r => r.Records.Select(rc => rc.Book)).ToList();
        }

        public Reader FindIncludeWithInfo(int id)
        {
            return _context.Set<Reader>().Where(r => r.Id == id)
                                         .Include(r => r.Records.Select(rc => rc.Book))
                                         .FirstOrDefault();
        }

        public IEnumerable<Reader> FindAllWithInfo()
        {
            var res = (from reader in _context.Set<Reader>()
                      join record in _context.Set<Record>()
                          on reader.Id equals record.ReaderId
                          into readerRecords
                      orderby reader.Name, reader.Surname, reader.Parentname
                      select new { Reader = reader, Records = readerRecords }).ToList();

            return res.Select(tmp =>
            {
                var rd = tmp.Reader;
                rd.Records = tmp.Records.ToList();
                return rd;
            });
        }

        public Reader FindWithInfo(int id)
        {
            var res = (from reader in _context.Set<Reader>()
                       where reader.Id == id
                       join record in _context.Set<Record>()
                           on reader.Id equals record.ReaderId
                           into readerRecords
                       orderby reader.Name, reader.Surname, reader.Parentname
                       select new { Reader = reader, Records = readerRecords }).ToList();

            return res.Select(tmp =>
            {
                var rd = tmp.Reader;
                rd.Records = tmp.Records.ToList();
                return rd;
            }).FirstOrDefault();
        }

        public IEnumerable<Reader> FindReadersByName(string name)
        {
            return _context.Set<Reader>().Where(r => (r.Name + " " + r.Surname + " " + r.Parentname).Contains(name))
                                         .ToList();
        }

        public IEnumerable<Reader> FindReadersByTicket(int ticketNumber)
        {
            return _context.Set<Reader>().Where(r => r.TicketNumber == ticketNumber)
                                         .ToList();
        }

        public IEnumerable<Reader> FindReadersByNameWithInfo(string name)
        {
            var res = (from reader in _context.Set<Reader>()
                       where (reader.Name + " " + reader.Surname + " " + reader.Parentname).Contains(name)
                       join record in _context.Set<Record>()
                           on reader.Id equals record.ReaderId
                           into readerRecords
                       orderby reader.Name, reader.Surname, reader.Parentname
                       select new { Reader = reader, Records = readerRecords }).ToList();

            return res.Select(tmp =>
            {
                var rd = tmp.Reader;
                rd.Records = tmp.Records.ToList();
                return rd;
            });
        }

        public IEnumerable<Reader> FindReadersByTicketWithInfo(int ticketNumber)
        {
            var res = (from reader in _context.Set<Reader>()
                       where reader.TicketNumber == ticketNumber
                       join record in _context.Set<Record>()                               
                           on reader.Id equals record.ReaderId
                           into readerRecords
                       orderby reader.Name, reader.Surname, reader.Parentname
                       select new { Reader = reader, Records = readerRecords }).ToList();

            return res.Select(tmp =>
            {
                var rd = tmp.Reader;
                rd.Records = tmp.Records.ToList();
                return rd;
            });
        }
    }
}
