using System;
using System.Collections.Generic;
using System.Text;
using Domain.Common;
using Domain.Category;



namespace Domain.ShopItem
{
    public class ShopItem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string ShortDescription { get; set; } = "";
        public string LongDescription { get; set; } = "";
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = "";
        public string ImageThumbnailUrl { get; set; } = "";
        public bool IsPieOfTheWeek { get; set; }
        public bool InStock { get; set; }
        public int CategoryId { get; set; }
        public Category.Category Category { get; set; } = new Category.Category();
        public string Notes { get; set; } = "";

    }
}
