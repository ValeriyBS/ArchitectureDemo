using System;
using Domain.Common;
using Domain.ShopItems;

namespace Domain.ShoppingCartItems
{
    public class ShoppingCartItem : IEntity, IEquatable<ShoppingCartItem>
    {
        public ShopItem ShopItem { get; set; } = null!;

        public int ShopItemId { get; set; }


        public int Amount { get; set; }
        public string ShoppingCartId { get; set; } = "";

        public int Id { get; set; }

        public bool Equals(ShoppingCartItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return ShoppingCartId == other.ShoppingCartId && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ShoppingCartItem) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ShoppingCartId, Id);
        }

        public static bool operator ==(ShoppingCartItem? left, ShoppingCartItem? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShoppingCartItem? left, ShoppingCartItem? right)
        {
            return !Equals(left, right);
        }
    }
}
