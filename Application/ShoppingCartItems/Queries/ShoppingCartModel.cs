using System.Collections.Generic;
using System.Linq;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCartItems.Queries
{
    public class ShoppingCartModel
    {
        public ShoppingCartModel(string cartId)
        {
            CartId = cartId;
        }

        public string CartId { get; }
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();


        public decimal ShoppingCartTotal => ShoppingCartItems.Sum(i => i.Amount * i.ShopItem.Price);

        public int ShoppingCartItemsCount => ShoppingCartItems.Sum(i => i.Amount);
    }
}