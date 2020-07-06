using Application.ShopItems.Queries.GetShopItemsList;
using Application.ShopItems.Queries.GetShopItemsListByCategory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Presentation.ShopItems
{
    public class ShopItemsController : Controller
    {
        private readonly IGetShopItemsListByCategoryQuery _getShopItemsListByCategoryQuery;
        private readonly IGetShopItemsListQuery _getShopItemsListQuery;

        public ShopItemsController(IGetShopItemsListQuery getShopItemsListQuery,
            IGetShopItemsListByCategoryQuery getShopItemsListByCategoryQuery)
        {
            _getShopItemsListQuery = getShopItemsListQuery;
            _getShopItemsListByCategoryQuery = getShopItemsListByCategoryQuery;
        }

        // GET: /<controller>/
        public IActionResult Index(int id)
        {
            return id > 0 ? View(_getShopItemsListByCategoryQuery.Execute(id)) : View(_getShopItemsListQuery.Execute());
        }

        public IActionResult Details(int id)
        {
            return View(_getShopItemsListQuery.Execute(id));
        }
    }
}