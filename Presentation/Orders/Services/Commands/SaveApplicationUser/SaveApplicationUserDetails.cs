using Presentation.Areas.Identity.Data;
using Presentation.Orders.Models;

namespace Presentation.Orders.Services.Commands.SaveApplicationUser
{
    public class SaveApplicationUserDetails : ISaveApplicationUserDetails
    {
        private readonly ApplicationDbContext _context;

        public SaveApplicationUserDetails(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Execute(string userId, CreateOrderViewModel viewModel)
        {
            var user = _context.Users.Find(userId);


            user.UserName = $"{viewModel.FirstName} {viewModel.LastName}";
            user.AddressLine1 = viewModel.AddressLine1;
            user.AddressLine2 = viewModel.AddressLine2;
            user.City = viewModel.City;
            user.Country = viewModel.Country;
            user.County = viewModel.County;
            user.PostCode = viewModel.PostCode;
            user.PhoneNumber = viewModel.PhoneNumber;

            _context.Users.Update(user);

            _context.SaveChangesAsync();
        }
    }
}