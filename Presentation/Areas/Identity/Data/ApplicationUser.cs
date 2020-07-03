using Microsoft.AspNetCore.Identity;

namespace Presentation.Areas.Identity.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string AddressLine1 { get; set; } = "";

        public string AddressLine2 { get; set; } = "";

        public string PostCode { get; set; } = "";

        public string City { get; set; } = "";

        public string County { get; set; } = "";

        public string Country { get; set; } = "";
    }
}