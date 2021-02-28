using Librarian.Domain.Models.Core;

namespace Librarian.Data.Repo.Abstract
{
    public interface IBookRepository<TIdentity> : IRepository<Book, TIdentity>
    {
    }
}
