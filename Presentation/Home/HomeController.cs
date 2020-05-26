using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Home
{
    public class HomeController : Controller
    {
        private readonly IGetCategoryListQuery _getCategoryList;

        public HomeController(IGetCategoryListQuery getCategoryList)
        {
            _getCategoryList = getCategoryList;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _getCategoryList.Execute();
            return View(categories);
        }
    }
}