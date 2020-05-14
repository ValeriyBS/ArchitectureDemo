using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Categories;
using Domain.Customers;
using Persistence.Shared;

namespace Persistence.Categories
{
    public class CategoryRepository : Repository<Category> , ICategoryRepository
    {
        public CategoryRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
