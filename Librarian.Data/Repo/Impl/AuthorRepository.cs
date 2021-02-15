using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class AuthorRepository : IAuthorRepository
    {
        public IEnumerable<Author> Find<TCriterion>(IFindStrategy<Author, TCriterion> strategy, TCriterion criterion)
        {
            if (strategy == null)
                return null;

            return DataBaseImitation.DBAuthors.Where(a => strategy.IsMatch(a, criterion)).ToHashSet();
        }

        public IEnumerable<Author> FindAll()
        {
            return DataBaseImitation.DBAuthors;
        }
    }
}
