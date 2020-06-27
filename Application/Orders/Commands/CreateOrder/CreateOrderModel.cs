using System;
using Application.Interfaces.Persistence;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderModel
    {
        public CreateOrderModel(string customerEmail, string cartId)
        {
            CustomerEmail = customerEmail ?? throw new ArgumentNullException(nameof(customerEmail));
            ShoppingCartId = cartId ?? throw new ArgumentNullException(nameof(cartId));
        }
        public string CustomerEmail { get;}

        public string ShoppingCartId { get;}
    }
}
