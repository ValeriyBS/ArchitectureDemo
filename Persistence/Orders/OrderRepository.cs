
using Application.Interfaces.Persistence;
using Domain.Orders;
using Persistence.Shared;

namespace Persistence.Orders
{
    public class OrderRepository : Repository<Order> , IOrderRepository
    {
        public OrderRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
