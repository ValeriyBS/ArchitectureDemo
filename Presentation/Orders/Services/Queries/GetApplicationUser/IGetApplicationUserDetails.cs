using System.Security.Claims;
using System.Threading.Tasks;
using Presentation.Orders.Models;

namespace Presentation.Orders.Services.Queries.GetApplicationUser
{
    public interface IGetApplicationUserDetails
    {
        Task<CreateOrderViewModel> Execute(ClaimsPrincipal userDetail);
    }
}