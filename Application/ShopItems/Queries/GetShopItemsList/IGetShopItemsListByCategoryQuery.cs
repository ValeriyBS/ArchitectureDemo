using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public interface IGetShopItemsListByCategoryQuery
    {
        List<ShopItemModel> Execute(int categoryId);
    }
}