using System.Collections.Generic;

namespace Application.Categories.Queries.GetCategoryList
{
    public interface IGetCategoryListQuery
    {
        List<CategoryModel> Execute();
    }
}
