﻿using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class ReaderRepository : IReaderRepository
    {
        public ICollection<Reader> Find<TCriterion>(IFindStrategy<Reader, TCriterion> strategy, TCriterion criterion)
        {
            if (strategy == null)
                return null;

            return DataBaseImitation.DBReaders.Where(r => strategy.IsMatch(r, criterion)).ToHashSet();
        }

        public ICollection<Reader> FindAll()
        {
            return DataBaseImitation.DBReaders;
        }
    }
}
