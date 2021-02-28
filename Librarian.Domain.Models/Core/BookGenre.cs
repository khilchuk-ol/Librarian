using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class BookGenre
    {
        public int Id { get; set; }

        public int BookGId { get; set; }
        [ForeignKey("BookGId")]
        public Book Book { get; set; }

        public int GenreId { get; set; }
        [ForeignKey("GenreId")]
        public Genre Genre { get; set; }
    }
}
