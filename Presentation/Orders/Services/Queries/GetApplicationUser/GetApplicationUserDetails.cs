using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Presentation.Areas.Identity.Data;
using Presentation.Orders.Models;

namespace Presentation.Orders.Services.Queries.GetApplicationUser
{
    internal class GetApplicationUserDetails : IGetApplicationUserDetails
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public GetApplicationUserDetails(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateOrderViewModel> Execute(ClaimsPrincipal userDetail)
        {
            var user = await GetCurrentUserAsync();

            return MapToCreateViewOrderModel(user);


            Task<ApplicationUser> GetCurrentUserAsync()
            {
                return _userManager.GetUserAsync(userDetail);
            }
        }

        private CreateOrderViewModel MapToCreateViewOrderModel(ApplicationUser user)
        {
            var firstName = user.UserName.Contains("@") ? "" : user.UserName.Split(" ").First();
            var lastName = user.UserName.Contains("@") ? "" : user.UserName.Split(" ").Last();

            var model = new CreateOrderViewModel
            {
                Email = user.Email,
                FirstName = firstName,
                LastName = lastName,
                AddressLine1 = user.AddressLine1,
                AddressLine2 = user.AddressLine2,
                City = user.City,
                Country = user.Country,
                County = user.County,
                PostCode = user.PostCode,
                PhoneNumber = user.PhoneNumber
            };
            return model;
        }
    }
}