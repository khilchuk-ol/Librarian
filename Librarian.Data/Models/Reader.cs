using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Models
{
    public sealed class Reader 
    {
        private static int identity = 0;
        public int Id { get; } = identity++;

        public int TicketNumber { get; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Parentname { get; set; }

        public string Fullname => string.Join(" ", new[] { Name, Surname, Parentname });

        public string Passport { get; set; }
        public string Phone { get; set; }

        public List<Record> Records { get; private set; } = new List<Record>();

        public List<Book> ReturnedBooks =>
            Records.Where(r => r.ReturnDate != null).Select(r => r.Book).ToList();

        public List<Book> CurrentlyBorrowedBooks =>
            Records.Where(r => r.ReturnDate == null).Select(r => r.Book).ToList();

        public Reader(int ticket)
        {
            if (ticket <= 0) 
                throw new ArgumentException("Bad argument for ticket number");
            TicketNumber = ticket;
        }
    }
}
