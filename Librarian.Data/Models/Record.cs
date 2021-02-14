using System;

namespace Librarian.Data.Models
{
    public sealed class Record
    {
        private static int identity = 0;
        public int Id { get; } = identity++;

        public DateTime BorrowDate { get; set; } = DateTime.Now;
        public DateTime? ReturnDate { get; set; }

        public Book Book { get; set; }
        public int BookId { get; set; }

        public Reader Reader { get; set; }
        public int ReaderId { get; set; }

        public TimeSpan DurationOfBorrow => (ReturnDate ?? DateTime.Now) - BorrowDate;

    }
}
