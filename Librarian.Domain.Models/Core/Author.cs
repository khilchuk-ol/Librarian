using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; } 
        public string Parentname { get; set; } 

        [NotMapped]
        public string Fullname => string.Join(" ", new[] { Name, Surname, Parentname});
        [NotMapped]
        public List<Book> Books { get; set; } = new List<Book>();

        public void AddBook(Book b) => Books.Add(b);
        public void RemoveBook(Book b) => Books.RemoveAll(bk => bk.Id == b.Id);
    }
}
