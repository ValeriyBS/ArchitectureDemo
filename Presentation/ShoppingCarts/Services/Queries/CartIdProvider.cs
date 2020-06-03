using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.ShoppingCarts.Services.Queries
{
    public class CartIdProvider
    {
        public string CartId { get; }

        private CartIdProvider(string cartId)
        {
            CartId = cartId;
        }

        public static CartIdProvider Execute(IServiceProvider services)
        {
           var session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var sessionGuid = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId",sessionGuid);

            return new CartIdProvider(sessionGuid);
           
        }



    }
}
