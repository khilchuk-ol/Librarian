using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IAuthorRepository
    {
        ICollection<Author> FindAll();

        ICollection<Author> Find<TCriterion>(IFindStrategy<Author, TCriterion> strategy, TCriterion criterion);
    }
}
