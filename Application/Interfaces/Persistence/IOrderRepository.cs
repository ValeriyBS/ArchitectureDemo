using System.Collections.Generic;
using Domain.Orders;

namespace Application.Interfaces.Persistence
{
    public interface IOrderRepository : IRepository<Order>
    {
        IList<Order> GetByUserId(string userId);
    }
}
