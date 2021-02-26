using Librarian.Data.Exceptions;
using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindBooksByAuthorStrategy : FindBooksStrategy
    {
        public override IEnumerable<Book> Find(IEnumerable<Book> elements, object author)
        {
            try
            {
                var criterion = (Author)author;
                return elements.Where(b => b.Authors.Select(a => a.Id).Contains(criterion.Id)).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(author.GetType(), this);
            }
        }
    }
}
