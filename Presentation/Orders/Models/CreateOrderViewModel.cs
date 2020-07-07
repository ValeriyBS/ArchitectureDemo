using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.OrderDetails;

namespace Presentation.Orders.Models
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "Please enter your first name")]
        [Display(Name = "First name")]
        [StringLength(50)]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "Please enter your last name")]
        [Display(Name = "Last name")]
        [StringLength(50)]
        public string LastName { get; set; } = "";

        [Required(ErrorMessage = "Please enter your address")]
        [StringLength(100)]
        [Display(Name = "Address Line 1")]
        public string AddressLine1 { get; set; } = "";

        [Display(Name = "Address Line 2")]
        public string AddressLine2 { get; set; } = "";

        [Required(ErrorMessage = "Please enter your postcode")]
        [Display(Name = "Postcode")]
        [StringLength(10, MinimumLength = 4)]
        public string PostCode { get; set; } = "";

        [Required(ErrorMessage = "Please enter your city")]
        [StringLength(50)]
        public string City { get; set; } = "";

        [Required(ErrorMessage = "Please enter your county")]
        [StringLength(10)]
        public string County { get; set; } = "";

        [Required(ErrorMessage = "Please enter your country")]
        [StringLength(50)]
        public string Country { get; set; } = "";

        [Required(ErrorMessage = "Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string PhoneNumber { get; set; } = "";

        public string Email { get; set; } = "";
        public List<OrderDetail> OrderDetails { get; set; } = null!;

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; } 
    }
}