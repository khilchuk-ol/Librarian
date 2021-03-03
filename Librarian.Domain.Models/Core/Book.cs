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

        public List<Author> Authors { get; set; } = new List<Author>();
        public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
