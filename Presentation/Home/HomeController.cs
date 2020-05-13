using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategoryList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.Home
{
    public class HomeController : Controller
    {
        private readonly IGetCategoryListQuery _query;

        public HomeController(IGetCategoryListQuery query)
        {
            _query = query;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _query.Execute();
            return View(categories);
        }
    }
}
