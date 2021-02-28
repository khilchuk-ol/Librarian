using Librarian.Domain.Models.Core;

namespace Librarian.Data.Repo.Abstract
{
    public interface IAuthorRepository<TIdentity> : IRepository<Author, TIdentity>
    {
    }
}
