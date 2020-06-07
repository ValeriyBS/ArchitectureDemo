using System;
using Domain.Categories;
using Domain.Common;

namespace Domain.ShopItems
{
    public class ShopItem : IEntity, IEquatable<ShopItem>
    {
        public string Name { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string LongDescription { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public string ImageThumbnailUrl { get; set; } = "";
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public string Notes { get; set; } = "";
        public int Id { get; set; }

        public bool Equals(ShopItem? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Name == other.Name && ShortDescription == other.ShortDescription &&
                   LongDescription == other.LongDescription && Price == other.Price && ImageUrl == other.ImageUrl &&
                   ImageThumbnailUrl == other.ImageThumbnailUrl && InStock == other.InStock &&
                   CategoryId == other.CategoryId && Category.Equals(other.Category) && Notes == other.Notes &&
                   Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((ShopItem) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(Name);
            hashCode.Add(ShortDescription);
            hashCode.Add(LongDescription);
            hashCode.Add(Price);
            hashCode.Add(ImageUrl);
            hashCode.Add(ImageThumbnailUrl);
            hashCode.Add(InStock);
            hashCode.Add(CategoryId);
            hashCode.Add(Category);
            hashCode.Add(Notes);
            hashCode.Add(Id);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(ShopItem? left, ShopItem? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ShopItem? left, ShopItem? right)
        {
            return !Equals(left, right);
        }
    }
}