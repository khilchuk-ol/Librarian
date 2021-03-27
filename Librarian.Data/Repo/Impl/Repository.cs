using Librarian.Data.Repo.Abstract;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Librarian.Data.Repo.Impl
{
    public class Repository<TEntity, TIdentity> : IRepository<TEntity, TIdentity> where TEntity : class
    {
        protected DbContext _context;

        public Repository(DbContext context)
        {
            _context = context;
        }

        public void Create(TEntity item)
        {
            _context.Set<TEntity>().Add(item);
        }

        public virtual TEntity Find(TIdentity id)
        {
            return _context.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> FindAll()
        {
            return _context.Set<TEntity>().ToList();
        }

        public IEnumerable<TEntity> GetPage(int offset, int amount)
        {
            return _context.Set<TEntity>().Skip(offset).Take(amount).ToList();
        }

        public void Remove(TEntity item)
        {
            _context.Set<TEntity>().Remove(item);
        }

        public void Update(TEntity item)
        {
            _context.Set<TEntity>().Attach(item);
            _context.Entry(item).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
