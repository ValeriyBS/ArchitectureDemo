using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Presentation.Areas.Identity.Data;

namespace Presentation.Orders.Services.Queries.GetApplicationUser
{
    internal class GetApplicationUserId : IGetApplicationUserId
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetApplicationUserId(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public string Execute(ClaimsPrincipal userDetail)
        {
            return _userManager.GetUserId(userDetail);
        }
    }
}