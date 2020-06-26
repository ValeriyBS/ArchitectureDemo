using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Customers;
using Domain.OrderDetails;

namespace Domain.Orders
{
    public class Order : IEntity
    {
        public List<OrderDetail> OrderDetails { get; set; } = null!;

        public Customer Customer { get; set; } = null!;

        public decimal OrderTotal { get; set; }

        public DateTime OrderPlaced { get; set; }

        public int Id { get; set; }
    }
}