using System.Collections.Generic;
using Application.ShopItems.Queries.GetShopItemsList;

namespace Application.ShopItems.Queries.GetShopItemsListByCategory
{
    public interface IGetShopItemsListByCategoryQuery
    {
        List<ShopItemModel> Execute(int categoryId);
    }
}