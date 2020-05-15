using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace PersistenceTests.Shared
{
    public class InMemoryDatabase<TEntity> : DbSet<TEntity> where TEntity : class
    {
        private readonly HashSet<TEntity> _entities;
        private readonly IQueryable<TEntity> _queryableSetOfEntities;


        public InMemoryDatabase(): this (Enumerable.Empty<TEntity>())
        {
        }

        private InMemoryDatabase(IEnumerable<TEntity> entities)
        {
            _entities = new HashSet<TEntity>();
            
            entities.ToList().ForEach(e=> _entities.Add(e));

            _queryableSetOfEntities = _entities.AsQueryable();

        }
    }
}
