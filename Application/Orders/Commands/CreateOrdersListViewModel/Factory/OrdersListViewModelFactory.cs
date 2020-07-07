using System.Collections.Generic;
using System.Linq;
using Domain.Orders;

namespace Application.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public class OrdersListViewModelFactory : IOrdersListViewModelFactory
    {
        public OrdersListViewModel Create(IList<Order> orders, int pageSize, int pageIndex)
        {
            var numberOfPages = GetNumberOfPages();

            var currentPageOrders = GetCurrentPageOrdersList();

            var ordersListViewModel = MapDataToOrdersListViewModel();

            return ordersListViewModel;


            int GetNumberOfPages()
            {
                pageSize = pageSize < 1 ? 1 : pageSize;

                return orders.Count / pageSize;
            }

            IList<Order> GetCurrentPageOrdersList()
            {
                pageIndex = pageIndex < 1 ? 1 : pageIndex;

                return orders
                    .Skip((pageIndex - 1) * pageSize)
                    .Take(pageSize).ToList();
            }


            bool HasPreviousPage()
            {
                return pageIndex > 1;
            }

            bool HasNextPage()
            {
                return pageIndex < numberOfPages;
            }

            OrdersListViewModel MapDataToOrdersListViewModel()
            {
                return new OrdersListViewModel()
                {
                    Orders = currentPageOrders,
                    PageSize = pageSize,
                    PageIndex = pageIndex,
                    numberOfPages = numberOfPages,
                    HasPrevPage = HasPreviousPage(),
                    HasNextPage = HasNextPage(),
                };
            }
        }
    }
}