using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Persistence;
using Domain.Categories;
using Domain.Customers;
using Microsoft.AspNetCore.Mvc;
using Persistence.Categories;

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
