﻿using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Data.Entity;

namespace Librarian.Data.Repo.Impl
{
    public class BookRepository : Repository<Book, int>, IBookRepository<int>
    {
        public BookRepository(DbContext context) : base(context) { }
    }
}
