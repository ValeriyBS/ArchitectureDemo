using System.Collections.Generic;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public interface IGetShopItemsListQuery
    {
        List<ShopItemModel> Execute();

        ShopItemModel Execute(int categoryIdItemId);



    }
}
