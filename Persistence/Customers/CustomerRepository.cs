using System;
using System.Collections.Generic;
using System.Text;
using Domain.Customers;
using Persistence.Shared;

namespace Persistence.Customers
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
