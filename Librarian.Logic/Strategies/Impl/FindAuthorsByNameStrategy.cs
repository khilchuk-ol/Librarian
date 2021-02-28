using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindAuthorsByNameStrategy : FindAuthorsStrategy
    {
        protected IAuthorRepository<int> _repository;

        public FindAuthorsByNameStrategy(IAuthorRepository<int> repository) => _repository = repository;

        public override IEnumerable<Author> Find(object name)
        {
            try
            {
                var criterion = (string)name;
                return _repository.FindAll().Where(a => a.Fullname.ToLower().Contains(criterion.Trim().ToLower())).ToList();
            }
            catch(InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Author>(name.GetType(), this);
            }
        }
    }
}
