namespace Application.Orders.Commands.CreateOrder
{
    public class CreateOrderModel
    {
        public CreateOrderModel(int customerId, string cartId)
        {
            CustomerId = customerId;
            ShoppingCartId = cartId;
        }
        public int CustomerId { get;}

        public string ShoppingCartId { get;}
    }
}
