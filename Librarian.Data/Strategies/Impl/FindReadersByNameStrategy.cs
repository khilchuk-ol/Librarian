using Librarian.Data.Exceptions;
using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindReadersByNameStrategy : FindReadersStrategy
    {
        public override IEnumerable<Reader> Find(IEnumerable<Reader> elements, object name)
        {
            try
            {
                var criterion = (string)name;
                return elements.Where(r => r.Fullname.ToUpperInvariant().Contains(criterion.Trim().ToUpperInvariant())).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Reader>(name.GetType(), this);
            }
        }
    }
}
