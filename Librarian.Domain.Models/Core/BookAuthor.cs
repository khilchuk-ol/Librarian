using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class BookAuthor
    {
        public int Id { get; set; }

        public int BookAId { get; set; }
        [ForeignKey("BookAId")]
        public Book Book { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("Authord")]
        public Author Author { get; set; }
    }
}
