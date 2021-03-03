using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class Record
    {
        public int Id { get; set; } 

        //[Column(TypeName = "datetime2")]
        public DateTime BorrowDate { get; set; }
        //[Column(TypeName = "datetime2")]
        public DateTime? ReturnDate { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }

        [ForeignKey("ReaderId")]
        public Reader Reader { get; set; }
        public int ReaderId { get; set; }

        [NotMapped]
        public TimeSpan DurationOfBorrow => (ReturnDate ?? DateTime.Now) - BorrowDate;

    }
}
