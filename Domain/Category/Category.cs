using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;

namespace Domain.Category
{
    public class Category : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; } = "";

        public string Description { get; set; } = "";

        public List<ShopItem.ShopItem> ShopItems { get; set; } = new List<ShopItem.ShopItem>();
    }
}
