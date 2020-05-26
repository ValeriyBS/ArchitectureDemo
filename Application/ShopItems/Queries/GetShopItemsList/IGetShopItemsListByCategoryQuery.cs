using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public interface IGetShopItemsListByCategoryQuery
    {
        List<ShopItemsModel> Execute(int categoryId);
    }
}