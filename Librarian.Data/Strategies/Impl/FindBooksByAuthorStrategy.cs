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
        public override IEnumerable<Book> Find(IEnumerable<Book> elements, object authorId)
        {
            try
            {
                var criterion = (int)authorId;
                return elements.Where(b => b.Authors.Select(a => a.Id).Contains(criterion)).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(authorId.GetType(), this);
            }
        }
    }
}
