﻿using Librarian.Data.Repo.Abstract;
using Librarian.Domain.Exceptions;
using Librarian.Domain.Models.Core;
using Librarian.Domain.Strategies.Abstract;
using System;
using System.Collections.Generic;

namespace Librarian.Domain.Strategies.Impl
{
    public class FindAuthorsByNameStrategy : FindAuthorsStrategy
    {
        protected IAuthorRepository _repository;

        public FindAuthorsByNameStrategy(IAuthorRepository repository) => _repository = repository;

        public override IEnumerable<Author> Find(object name)
        {
            try
            {
                var criterion = (string)name;
                return _repository.FindAuthorsByName(criterion.Trim());
            }
            catch(InvalidCastException)
            {
                throw new InvalidStrategyArgumentTypeException<Author>(name.GetType(), this);
            }
        }
    }
}
