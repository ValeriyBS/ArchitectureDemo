using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Category.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly IGetCategoryListQuery _getCategoryListQuery;

        public CategoryMenu(IGetCategoryListQuery getCategoryListQuery)
        {
            _getCategoryListQuery = getCategoryListQuery;
        }


        public IViewComponentResult Invoke()
        {
            var categories = _getCategoryListQuery.Execute();
            return View(categories);
        }
    }
}