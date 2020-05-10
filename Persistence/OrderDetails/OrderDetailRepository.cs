using Application.Interfaces.Persistence;
using Domain.OrderDetails;
using Persistence.Shared;

namespace Persistence.OrderDetails
{
    public class OrderDetailRepository : Repository<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
