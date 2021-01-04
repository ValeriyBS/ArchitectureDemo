using System;
using Domain.Common;

namespace Domain.Customers
{
    public class Customer : IEntity, IEquatable<Customer>
    {

        public string UserId { get; set; } = "";


        public int Id { get; set; }

        public bool Equals(Customer? other)
        {
            if (other is null) return false;
            if (ReferenceEquals(this, other)) return true;
            return UserId == other.UserId && Id == other.Id;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Customer) obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(UserId, Id);
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