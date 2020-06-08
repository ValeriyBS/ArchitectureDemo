using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMapper;

namespace Application.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IGetCategoryListQuery
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoryListQuery(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }
        public List<CategoryModel> Execute()
        {
            var categories = _categoryRepository.GetAll()
                .Select(c => _mapper.Map<CategoryModel>(c));
            return categories.ToList();
        }
    }
}
