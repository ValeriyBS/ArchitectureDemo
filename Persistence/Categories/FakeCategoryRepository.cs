using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.Categories;

namespace Persistence.Categories
{
    public class FakeCategoryRepository : ICategoryRepository
    {
        private IQueryable<Category> _categories;

        public FakeCategoryRepository()
        {
            _categories = new EnumerableQuery<Category>(new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Name1"
                },
                new Category
                {
                    Id = 2,
                    Name = "Name2"
                }
            });
        }
        public IQueryable<Category> GetAll()
        {
            return _categories;
        }

        public Category Get(int id)
        {
            return _categories.Single(c => c.Id == id);
        }

        public void Add(Category entity)
        {
            _categories.Append(entity);
        }

        public void Remove(Category entity)
        {
            var entityToRemove= _categories.SingleOrDefault(c => c.Id == entity.Id);
            if (entityToRemove is null) return;

            var newCollection = _categories.Where(c => c != entityToRemove);

            _categories = newCollection;

        }
    }
}
