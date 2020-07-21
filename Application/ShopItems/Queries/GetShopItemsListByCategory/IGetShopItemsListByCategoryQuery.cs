using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsListByCategory
{
    public interface IGetShopItemsListByCategoryQuery
    {
        List<ShopItemModel> Execute(int categoryId);
    }
}