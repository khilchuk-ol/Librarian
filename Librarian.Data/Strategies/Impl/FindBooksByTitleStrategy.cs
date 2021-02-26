using Librarian.Data.Exceptions;
using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindBooksByTitleStrategy : FindBooksStrategy
    {
        public override IEnumerable<Book> Find(IEnumerable<Book> elements, object title)
        {
            try
            {
                var criterion = (string)title;
                return elements.Where(b => b.Title.ToUpperInvariant().Contains(criterion.Trim().ToUpperInvariant())).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(title.GetType(), this);
            }
        }
    }
}
