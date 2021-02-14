using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;

namespace Librarian.Data.Repo
{
    public interface IBookRepository
    {
        ICollection<Book> FindAll();

        ICollection<Book> Find<TCriterion>(IFindStrategy<Book, TCriterion> strategy, TCriterion criterion);
    }
}
