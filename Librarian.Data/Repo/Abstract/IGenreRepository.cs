using Librarian.Domain.Models.Core;

namespace Librarian.Data.Repo.Abstract
{
    public interface IGenreRepository<TIdentity> : IRepository<Genre,TIdentity>
    {
    }
}
