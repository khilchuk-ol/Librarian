using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace Librarian.Domain.Models.Core
{
    public class Reader 
    {
        public int Id { get; set; }

        public int TicketNumber { get; set; }
        
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        public string Parentname { get; set; }

        [NotMapped]
        public string Fullname => string.Join(" ", new[] { Name, Surname, Parentname });

        public string Passport { get; set; }
        [Required]
        public string Phone { get; set; }

        public List<Record> Records { get; set; } = new List<Record>();

        [NotMapped]
        public List<Book> ReturnedBooks =>
            Records.Where(r => r.ReturnDate != null).Select(r => r.Book).ToList();

        [NotMapped]
        public List<Book> CurrentlyBorrowedBooks =>
            Records.Where(r => r.ReturnDate == null).Select(r => r.Book).ToList();

        public Reader(int ticket)
        {
            if (ticket <= 0) 
                throw new ArgumentException("Bad argument for ticket number");
            TicketNumber = ticket;
        }

        public Reader() { }

        public void AddRecord(Record r) => Records.Add(r);
        public void RemoveRecord(Record r) => Records.RemoveAll(rc => rc.Id == r.Id);
    }
}
