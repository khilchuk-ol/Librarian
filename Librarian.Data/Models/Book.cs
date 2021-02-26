using System;
using System.Collections.Generic;

namespace Librarian.Data.Models
{
    public sealed class Book
    {
        private static int identity = 0;
        public int Id { get; } = identity++;

        public int Number { get; set; }
        public string Title { get; set; }
        public int PageCount { get; set; }
        public DateTime ReleaseDate { get; set; }

        public bool IsBorrowed { get; set; }

        public List<Author> Authors { get; private set; } = new List<Author>();
        public List<Genre> Genres { get; private set; } = new List<Genre>();
    }
}
