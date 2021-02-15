using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> FindAll();

        IEnumerable<Author> Find<TCriterion>(IFindStrategy<Author, TCriterion> strategy, TCriterion criterion);
    }
}
