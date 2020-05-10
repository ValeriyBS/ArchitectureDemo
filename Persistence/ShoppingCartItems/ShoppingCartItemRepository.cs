
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;
using Persistence.Shared;

namespace Persistence.ShoppingCartItems
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        public ShoppingCartItemRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
        }
    }
}
