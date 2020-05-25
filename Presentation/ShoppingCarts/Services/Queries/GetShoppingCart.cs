using System;
using Application.ShoppingCarts.Factory;
using Application.ShoppingCarts.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.ShoppingCarts.Services.Queries
{
    public class GetShoppingCart
    {
        //private readonly IShoppingCartFactory _shoppingCartFactory;
        //public IShoppingCart ShoppingCart { get; }

        public string SessionId { get; private set; }


        //private GetShoppingCart(IShoppingCartFactory shoppingCartFactory)
        //{
        //    _shoppingCartFactory = shoppingCartFactory;
        //}

        public static GetShoppingCart Execute(IServiceProvider services)
        {
            var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var sessionGuid = session.GetString("CartId") ?? Guid.NewGuid().ToString();


            session.SetString("CartId",sessionGuid);

            var context = services.GetService<ShoppingCartFactory>();


            //var shoppingCart = new GetShoppingCart(context);

            //var sc= shoppingCart._shoppingCartFactory.Create(cartId);

            return new GetShoppingCart(){SessionId = sessionGuid};
           
        }

    }
}
