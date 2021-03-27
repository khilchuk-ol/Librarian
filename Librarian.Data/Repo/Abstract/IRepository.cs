using System.Collections.Generic;

namespace Librarian.Data.Repo.Abstract
{
    public interface IRepository<TEntity, TIdentity>
    {
        void Create(TEntity item);
        void Update(TEntity item);
        void Remove(TEntity item);
        IEnumerable<TEntity> FindAll();
        TEntity Find(TIdentity id);
        IEnumerable<TEntity> GetPage(int offset, int amount);
    }
}
