using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindReadersByTicketStrategy : FindReadersStrategy
    {
        protected IReaderRepository _repository;

        public FindReadersByTicketStrategy(IReaderRepository repository) => _repository = repository;

        public override IEnumerable<Reader> Find(object ticketNumber)
        {
            try
            {
                var criterion = (int)ticketNumber;
                return _repository.FindReadersByTicket(criterion);
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Reader>(ticketNumber.GetType(), this);
            }
        }
    }
}
