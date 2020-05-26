using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Common;

namespace Persistence.Shared
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _databaseContext.Set<TEntity>();
        }

        public TEntity Get(int id)
        {
            return _databaseContext.Set<TEntity>().Single(t => t.Id == id);
        }

        public virtual void Add(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Add(entity);
        }


        public void Remove(TEntity entity)
        {
            _databaseContext.Set<TEntity>().Remove(entity);
        }
    }
}