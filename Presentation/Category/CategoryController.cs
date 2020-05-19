using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Category
{
    public class CategoryController : Controller
    {
        private readonly IGetCategoryListQuery _getCategoryListQuery;

        public CategoryController(IGetCategoryListQuery getCategoryListQuery)
        {
            _getCategoryListQuery = getCategoryListQuery;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {

            return View(_getCategoryListQuery.Execute());
        }
    }
}
