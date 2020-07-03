using Presentation.Orders.Models;

namespace Presentation.Orders.Services.Commands.SaveApplicationUser
{
    public interface ISaveApplicationUserDetails
    {
        void Execute(string userId, CreateOrderViewModel viewModel);
    }
}