using System.Collections.Generic;
using Domain.Categories;

namespace Application.Categories.Queries.GetCategoryList
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";

       
    }
}
