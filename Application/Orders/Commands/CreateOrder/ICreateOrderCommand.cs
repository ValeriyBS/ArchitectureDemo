namespace Application.Orders.Commands.CreateOrder
{
    public interface ICreateOrderCommand
    {
        void Execute(CreateOrderModel model);
    }
}