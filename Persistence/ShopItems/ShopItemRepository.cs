
using Application.Interfaces.Persistence;
using Domain.ShopItems;
using Persistence.Shared;

namespace Persistence.ShopItems
{
    public class ShopItemRepository : Repository<ShopItem>, IShopItemRepository
    {
        public ShopItemRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
