using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Common;

namespace Persistence.Shared
{
    internal class Repository<T> : IRepository<T> where T : class, IEntity
    {
        private readonly IDatabaseContext _databaseContext;

        public Repository(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public IQueryable<T> GetAll()
        {
            return _databaseContext.Set<T>();
        }

        public T Get(int id)
        {
            return _databaseContext.Set<T>().Single(t => t.Id == id);
        }

        public void Add(T entity)
        {
            _databaseContext.Set<T>().Add(entity);
        }


        public void Remove(T entity)
        {
            _databaseContext.Set<T>().Remove(entity);
        }
    }
}