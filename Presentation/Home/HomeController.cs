using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Home
{
    public class HomeController : Controller
    {
        private readonly IGetCategoryListQuery _getCategoryListQuery;

        public HomeController(IGetCategoryListQuery getCategoryListQuery)
        {
            _getCategoryListQuery = getCategoryListQuery;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _getCategoryListQuery.Execute();
            return View(categories);
        }
    }
}