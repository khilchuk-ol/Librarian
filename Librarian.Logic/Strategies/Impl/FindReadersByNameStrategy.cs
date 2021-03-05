using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindReadersByNameStrategy : FindReadersStrategy
    {
        protected IReaderRepository _repository;

        public FindReadersByNameStrategy(IReaderRepository repository) => _repository = repository;

        public override IEnumerable<Reader> Find(object name)
        {
            try
            {
                var criterion = (string)name;
                return _repository.FindAll().Where(r => r.Fullname.ToUpperInvariant().Contains(criterion.Trim().ToUpperInvariant())).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Reader>(name.GetType(), this);
            }
        }
    }
}
