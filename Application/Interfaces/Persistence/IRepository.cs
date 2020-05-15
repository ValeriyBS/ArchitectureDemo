using System.Linq;

namespace Application.Interfaces.Persistence
{
    public interface IRepository<TEntity>
    {
        IQueryable<TEntity> GetAll();

        TEntity Get(int id);

        void Add(TEntity entity);

        void Remove(TEntity entity);
    }
}
