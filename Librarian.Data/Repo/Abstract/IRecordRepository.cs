using Librarian.Domain.Models.Core;

namespace Librarian.Data.Repo.Abstract
{
    public interface IRecordRepository<TIdentity> : IRepository<Record, TIdentity>
    {
    }
}
