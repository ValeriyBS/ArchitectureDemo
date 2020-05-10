using Domain.Categories;
using Domain.Common;

namespace Domain.ShopItems
{
    public class ShopItem : IEntity
    {
        public string Name { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string LongDescription { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public string ImageThumbnailUrl { get; set; } = "";
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = new Category();
        public string Notes { get; set; } = "";
        public int Id { get; set; }
    }
}