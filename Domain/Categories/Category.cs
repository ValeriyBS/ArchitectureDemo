using System.Collections.Generic;
using Domain.Common;
using Domain.ShopItems;

namespace Domain.Categories
{
    public class Category : IEntity
    {
        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<ShopItem> ShopItems { get; set; } = new List<ShopItem>();
        public int Id { get; set; }
    }
}