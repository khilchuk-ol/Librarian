using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindBooksByTitleStrategy : FindBooksStrategy
    {
        protected IBookRepository _repository;

        public FindBooksByTitleStrategy(IBookRepository repository) => _repository = repository;

        public override IEnumerable<Book> Find(object title)
        {
            try
            {
                var criterion = (string)title;
                return _repository.FindBooksByTitle(criterion.Trim());
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(title.GetType(), this);
            }
        }
    }
}
