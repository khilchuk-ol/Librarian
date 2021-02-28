using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindReadersByTicketStrategy : FindReadersStrategy
    {
        protected IReaderRepository<int> _repository;

        public FindReadersByTicketStrategy(IReaderRepository<int> repository) => _repository = repository;

        public override IEnumerable<Reader> Find(object ticketNumber)
        {
            try
            {
                var criterion = (int)ticketNumber;
                return _repository.FindAll().Where(r => r.TicketNumber == criterion).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Reader>(ticketNumber.GetType(), this);
            }
        }
    }
}
