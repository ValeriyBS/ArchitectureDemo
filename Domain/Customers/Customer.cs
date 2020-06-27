using System;
using Domain.Common;

namespace Domain.Customers
{
    public class Customer : IEntity, IEquatable<Customer>
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

        public bool Equals(Customer? other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return FirstName == other.FirstName && LastName == other.LastName && AddressLine1 == other.AddressLine1 &&
                   AddressLine2 == other.AddressLine2 && PostCode == other.PostCode && City == other.City &&
                   County == other.County && Country == other.Country && PhoneNumber == other.PhoneNumber &&
                   Email == other.Email && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            var hashCode = new HashCode();
            hashCode.Add(FirstName);
            hashCode.Add(LastName);
            hashCode.Add(AddressLine1);
            hashCode.Add(AddressLine2);
            hashCode.Add(PostCode);
            hashCode.Add(City);
            hashCode.Add(County);
            hashCode.Add(Country);
            hashCode.Add(PhoneNumber);
            hashCode.Add(Email);
            hashCode.Add(Id);
            return hashCode.ToHashCode();
        }

        public static bool operator ==(Customer? left, Customer? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Customer? left, Customer? right)
        {
            return !Equals(left, right);
        }
    }
}