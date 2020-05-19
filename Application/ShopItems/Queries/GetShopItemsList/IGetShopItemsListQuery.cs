using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public interface IGetShopItemsListQuery
    {
        List<ShopItemsModel> Execute();

        List<ShopItemsModel> Execute(int categoryId);

        List<ShopItemsModel> Execute(string categoryName);


    }
}
