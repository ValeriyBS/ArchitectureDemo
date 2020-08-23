using Microsoft.AspNetCore.Mvc;
namespace Presentation.Areas.Identity.Components
{
    public class UserMenu : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}