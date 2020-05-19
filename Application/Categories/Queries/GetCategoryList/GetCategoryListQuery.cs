using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;

namespace Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IGetCategoryListQuery
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryListQuery(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public List<CategoryModel> Execute()
        {
            var categories = _categoryRepository.GetAll()
                .Select(c => new CategoryModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description
                    
                });

            return categories.ToList();
        }
    }
}
