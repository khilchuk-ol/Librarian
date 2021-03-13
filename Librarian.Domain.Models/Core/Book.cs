using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Librarian.Domain.Models.Core
{
    public class Book
    {
        public int Id { get; set; } 

        public int Number { get; set; }
        [Required]
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public bool IsBorrowed { get; set; }

        [NotMapped]
        public List<Author> Authors { get; set; } = new List<Author>();
        [NotMapped]
        public List<Genre> Genres { get; set; } = new List<Genre>();

        public void AddAuthor(Author a) => Authors.Add(a);
        public void RemoveAuthor(Author a) => Authors.RemoveAll(at => at.Id == a.Id);

        public void AddGenre(Genre g) => Genres.Add(g);
        public void RemoveGenre(Genre g) => Genres.RemoveAll(gn => gn.Id == g.Id);
    }
}
