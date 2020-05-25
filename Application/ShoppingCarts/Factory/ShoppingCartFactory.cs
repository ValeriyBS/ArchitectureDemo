using System;
using Application.ShoppingCarts.Queries;

namespace Application.ShoppingCarts.Factory
{
    public class ShoppingCartFactory : IShoppingCartFactory
    {
        //private readonly IGetShoppingCartItemsListQuery _getShoppingCartItemsListQuery;

        //public ShoppingCartFactory(IGetShoppingCartItemsListQuery getShoppingCartItemsListQuery)
        //{
        //    _getShoppingCartItemsListQuery = getShoppingCartItemsListQuery;
        //}
        public ShoppingCart Create(string cartId)
        {
            //var container = ApplicationContainerConfig.Configure();

            //var getShoppingCartItemsListQuery = container.Resolve<IGetShoppingCartItemsListQuery>();

            var newCartId = cartId ?? Guid.NewGuid().ToString();
            var shoppingCart = new ShoppingCart(newCartId);
            return shoppingCart;
        }
    }
}