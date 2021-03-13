using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class Genre
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [NotMapped]
        public List<Book> Books { get; set; } = new List<Book>();

        public Genre(string name) => Name = name;

        public Genre() { }

        public void AddBook(Book b) => Books.Add(b);
        public void RemoveBook(Book b) => Books.RemoveAll(bk => bk.Id == b.Id);
    }
}
