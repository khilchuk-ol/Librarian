using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindBooksByAuthorStrategy : FindBooksStrategy
    {
        protected IBookRepository _repository;

        public FindBooksByAuthorStrategy(IBookRepository repository) => _repository = repository;

        public override IEnumerable<Book> Find(object author)
        {
            try
            {
                var criterion = (Author)author;
                return _repository.FindBooksByAuthor(criterion);
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(author.GetType(), this);
            }
        }
    }
}
