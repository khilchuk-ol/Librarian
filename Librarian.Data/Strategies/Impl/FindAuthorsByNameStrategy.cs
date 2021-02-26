using Librarian.Data.Exceptions;
using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindAuthorsByNameStrategy : FindAuthorsStrategy
    {
        public override IEnumerable<Author> Find(IEnumerable<Author> elements, object name)
        {
            try
            {
                var criterion = (string)name;
                return elements.Where(a => a.Fullname.ToLower().Contains(criterion.Trim().ToLower())).ToList();
            }
            catch(InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Author>(name.GetType(), this);
            }
        }
    }
}
