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
        private readonly ICategoryRepository _query;

        public HomeController(ICategoryRepository query)
        {
            _query = query;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var categories = _query.GetAll();
            return View(categories);
        }
    }
}
