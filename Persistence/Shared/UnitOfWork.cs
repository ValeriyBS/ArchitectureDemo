using Application.Interfaces.Persistence;

namespace Persistence.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseContext _databaseContext;

        public UnitOfWork(IDatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
            _databaseContext.Save();
        }
    }
}