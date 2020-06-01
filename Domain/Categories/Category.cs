using System;
using System.Collections.Generic;
using Domain.Common;
using Domain.ShopItems;

namespace Domain.Categories
{
    public class Category : IEntity, IEquatable<Category>
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
        public int Id { get; set; }

        public bool Equals(Category? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && Description == other.Description  && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Category) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Description, ShopItems, Id);
        }

        public static bool operator ==(Category? left, Category? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Category? left, Category? right)
        {
            return !Equals(left, right);
        }
    }
}