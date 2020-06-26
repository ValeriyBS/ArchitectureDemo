using AutoMapper;
using Domain.Categories;

namespace Application.Categories.Queries.GetCategoryList
{
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}