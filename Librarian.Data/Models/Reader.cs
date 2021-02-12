using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Models
{
    public sealed class Reader : Entity
    {
        public int TicketNumber { get; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Parentname { get; set; }

        public string Fullname => string.Join(" ", new[] { Name, Surname, Parentname });

        public string Passport { get; set; }
        public string Phone { get; set; }

        public ICollection<Record> Records { get; private set; } = new HashSet<Record>();

        public ICollection<Book> ReturnedBooks =>
            Records.Where(r => r.ReturnDate != null).Select(r => r.Book).ToHashSet();

        public ICollection<Book> CurrentlyBorrowedBooks =>
            Records.Where(r => r.ReturnDate == null).Select(r => r.Book).ToHashSet();

        public Reader(int ticket)
        {
            if (ticket <= 0) 
                throw new ArgumentException("Bad argument for ticket number");
            TicketNumber = ticket;
        }
    }
}
