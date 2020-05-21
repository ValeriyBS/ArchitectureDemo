using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.ShopItems.Queries.GetShopItemsList;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.ShopItems
{
    public class ShopItemsController : Controller
    {
        private readonly IGetShopItemsList _getShopItemsList;

        public ShopItemsController(IGetShopItemsList getShopItemsList)
        {
            _getShopItemsList = getShopItemsList;
        }
        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            return id>0 ? View(_getShopItemsList.Execute(id)) : View(_getShopItemsList.Execute());
        }

    }
}
