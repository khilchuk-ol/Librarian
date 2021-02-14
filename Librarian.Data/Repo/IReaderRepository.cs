using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IReaderRepository
    {
        ICollection<Reader> FindAll();

        ICollection<Reader> Find<TCriterion>(IFindStrategy<Reader, TCriterion> strategy, TCriterion criterion);
    }
}
