using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class GenreBook
    {
        public int Id { get; set; }

        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
        public int GenreId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }
        public int BookId { get; set; }
    }
}
