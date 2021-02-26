using Librarian.Data.Exceptions;
using Librarian.Data.Models;
using Librarian.Data.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Strategies.Impl
{
    public class FindReadersByTicketStrategy : FindReadersStrategy
    {
        public override IEnumerable<Reader> Find(IEnumerable<Reader> elements, object ticketNumber)
        {
            try
            {
                var criterion = (int)ticketNumber;
                return elements.Where(r => r.TicketNumber == criterion).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Reader>(ticketNumber.GetType(), this);
            }
        }
    }
}
