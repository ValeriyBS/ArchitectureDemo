using System.Collections.Generic;
using Domain.Orders;

namespace Application.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public class OrdersListViewModel
    {
        public IEnumerable<Order> Orders { get; set; } = new List<Order>();
        public int PageSize { get; set; } = 3;

        public int PageIndex { get; set; } = 1;

        public int NumberOfPages { get; set; }

        public bool HasNextPage { get; set; }
        public bool HasPrevPage { get; set; }
    }
}
