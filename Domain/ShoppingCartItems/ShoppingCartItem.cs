using Domain.Common;
using Domain.ShopItems;

namespace Domain.ShoppingCartItems
{
    public class ShoppingCartItem : IEntity
    {
        public ShopItem ShopItem { get; set; } = new ShopItem();
        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } = "";

        public int Id { get; set; }
    }
}
