using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public interface IGetShopItemsListQuery
    {
        List<ShopItemsModel> Execute();

        ShopItemsModel Execute(int categoryIdItemId);



    }
}
