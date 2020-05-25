using System;
using System.Collections.Generic;
using Domain.ShoppingCartItems;

namespace Application.ShoppingCarts.Queries
{
    public class ShoppingCart : IEquatable<ShoppingCart>, IShoppingCart
    {

        public ShoppingCart(string cartId)
        {
            CartId = cartId;
        }

        public string CartId { get; } 
        public List<ShoppingCartItem> ShoppingCartItems { get; set; } = new List<ShoppingCartItem>();





        public bool Equals(ShoppingCart? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return CartId == other.CartId && ShoppingCartItems.Equals(other.ShoppingCartItems);
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingCart) obj);
        }

        public override int GetHashCode()
        {
            return ShoppingCartItems.GetHashCode();
        }

        public static bool operator ==(ShoppingCart? left, ShoppingCart? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShoppingCart? left, ShoppingCart? right)
        {
            return !Equals(left, right);
        }
    }
}
