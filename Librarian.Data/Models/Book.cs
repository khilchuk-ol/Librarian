﻿using System;
using System.Collections.Generic;

namespace Librarian.Data.Models
{
    public sealed class Book : Entity
    {
        public int Number { get; set; }

        public string Title { get; set; }

        public int PageCount { get; set; }

        public DateTime ReleaseDate { get; set; }

        public bool IsBorrowed { get; set; }

        public ICollection<Author> Authors { get; private set; } = new HashSet<Author>();
        public ICollection<Genre> Genres { get; private set; } = new HashSet<Genre>();
    }
}
