using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using WebApplicationDemo.Data;

namespace WebApplicationDemo.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly ITPQ3Context context;
        public Repository(ITPQ3Context _context)
        {
            context = _context;
        }
        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(int id)
        {
            return context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }

        public void Remove(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }
    }
}
