using Domain.Common;

namespace Domain.Customers
{
    public class Customer : IEntity
    {
        public string FirstName { get; set; } = "";

        public string LastName { get; set; } = "";

        public string AddressLine1 { get; set; } = "";

        public string AddressLine2 { get; set; } = "";

        public string PostCode { get; set; } = "";

        public string City { get; set; } = "";

        public string County { get; set; } = "";

        public string Country { get; set; } = "";

        public string PhoneNumber { get; set; } = "";

        public string Email { get; set; } = "";


        public int Id { get; set; }
    }
}