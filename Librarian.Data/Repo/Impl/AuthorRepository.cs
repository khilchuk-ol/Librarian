﻿using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Models.Core;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : Repository<Author, int>, IAuthorRepository
    {
        public AuthorRepository(DbContext context) : base(context) { }

        public override IEnumerable<Author> FindAll()
        {
            return _context.Set<Author>().Include(a => a.Books).ToList();
        }

        public override Author Find(int id)
        {
            return _context.Set<Author>().Where(a => a.Id == id)
                                         .Include(a => a.Books)
                                         .FirstOrDefault();
        }

        public IEnumerable<Author> FindAuthorsByName(string name)
        {
            return _context.Set<Author>().Where(a => a.Fullname.Contains(name))
                                         .Include(a => a.Books)
                                         .ToList();
        }
    }
}
