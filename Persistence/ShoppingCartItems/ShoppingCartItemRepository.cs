
using Application.Interfaces.Persistence;
using Domain.ShoppingCartItems;
using Persistence.Shared;

namespace Persistence.ShoppingCartItems
{
    public class ShoppingCartItemRepository : Repository<ShoppingCartItem>, IShoppingCartItemRepository
    {
        private readonly IDatabaseContext _databaseContext;

        public ShoppingCartItemRepository(IDatabaseContext databaseContext) : base(databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public void Save()
        {
           _databaseContext.Save();
        }
    }
}
