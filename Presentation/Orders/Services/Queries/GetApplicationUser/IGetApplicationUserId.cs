using System.Security.Claims;

namespace Presentation.Orders.Services.Queries.GetApplicationUser
{
    public interface IGetApplicationUserId
    {
        string Execute(ClaimsPrincipal userDetail);
    }
}