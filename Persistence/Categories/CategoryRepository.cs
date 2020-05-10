using System.Linq;
using Application.Interfaces.Persistence;
using Domain.Categories;
using Domain.Customers;
using Persistence.Shared;

namespace Persistence.Categories
{
    public class CategoryRepository : Repository<Customer> , ICustomerRepository
    {
        public CategoryRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
