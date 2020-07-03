using System;

namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderModel
    {
        public CreateOrderModel(string customerId, string cartId)
        {
            CustomerId = customerId ?? throw new ArgumentNullException(nameof(customerId));
            ShoppingCartId = cartId ?? throw new ArgumentNullException(nameof(cartId));
        }

        public string CustomerId { get; }

        public string ShoppingCartId { get; }
    }
}