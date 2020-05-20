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

        [ScaffoldColumn(false)] public decimal OrderTotal { get; set; }

        [ScaffoldColumn(false)] public DateTime OrderPlaced { get; set; }

        public int Id { get; set; }
    }
}