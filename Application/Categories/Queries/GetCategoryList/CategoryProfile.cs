using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Domain.Categories;

namespace Application.Categories.Queries.GetCategoryList
{
    [ExcludeFromCodeCoverage]
    internal class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryModel>();
        }
    }
}