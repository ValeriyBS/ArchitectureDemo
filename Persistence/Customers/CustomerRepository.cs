using Application.Interfaces.Persistence;
using Domain.Customers;
using Persistence.Shared;

namespace Persistence.Customers
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}