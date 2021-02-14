using Librarian.Data.Models;
using Librarian.Data.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class BookRepository : IBookRepository
    {
        public ICollection<Book> Find<TCriterion>(IFindStrategy<Book, TCriterion> strategy, TCriterion criterion)
        {
            if (strategy == null)
                return null;

            return DataBaseImitation.DBBooks.Where(b => strategy.IsMatch(b, criterion)).ToHashSet();
        }

        public ICollection<Book> FindAll()
        {
            return DataBaseImitation.DBBooks;
        }
    }
}
