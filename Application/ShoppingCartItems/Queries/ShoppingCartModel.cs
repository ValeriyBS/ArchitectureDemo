using System;
using System.Collections.Generic;
using System.Text;
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

        public decimal ShoppingCartTotal { get; set; }
    }
}
