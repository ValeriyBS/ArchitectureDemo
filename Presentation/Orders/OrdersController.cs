using Microsoft.AspNetCore.Mvc;

namespace Presentation.Orders
{
    public class OrdersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}