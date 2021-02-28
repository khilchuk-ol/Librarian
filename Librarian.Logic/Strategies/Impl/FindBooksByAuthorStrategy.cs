using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindBooksByAuthorStrategy : FindBooksStrategy
    {
        protected IBookRepository<int> _repository;

        public FindBooksByAuthorStrategy(IBookRepository<int> repository) => _repository = repository;

        public override IEnumerable<Book> Find(object author)
        {
            try
            {
                var criterion = (Author)author;
                return _repository.FindAll().Where(b => b.Authors.Select(a => a.Id).Contains(criterion.Id)).ToList();
            }
            catch (InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Book>(author.GetType(), this);
            }
        }
    }
}
