using Domain.Common;
using Domain.Orders;
using Domain.ShopItems;

namespace Domain.OrderDetails
{
    public class OrderDetail : IEntity
    {
        public int OrderId { get; set; }
        public int ShopItemId { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
        public ShopItem ShopItem { get; set; } = null!;
        public Order Order { get; set; } = null!;
        public int Id { get; set; }
    }
}
