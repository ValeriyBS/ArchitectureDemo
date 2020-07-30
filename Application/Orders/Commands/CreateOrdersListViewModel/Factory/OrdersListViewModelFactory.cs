using System.Collections.Generic;
using System.Linq;
using Domain.Orders;
using Microsoft.VisualBasic;

namespace Application.Orders.Commands.CreateOrdersListViewModel.Factory
{
    public class OrdersListViewModelFactory : IOrdersListViewModelFactory
    {
        public OrdersListViewModel Create(IList<Order> orders, int pageSize, int pageIndex)
        {
            var ordersListViewModel = new OrdersListViewModel(){OrdersPageRatio = 10};

            var numberOfPages = GetNumberOfPages();

            var currentPageOrders = GetCurrentPageOrdersList();

            PopulateModelWithData(ref ordersListViewModel);

            return ordersListViewModel;


            int GetNumberOfPages()
            {
                pageSize = pageSize < 1 ? orders.Count/ ordersListViewModel.OrdersPageRatio: pageSize;

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

            void PopulateModelWithData(ref OrdersListViewModel model)
            {

                model.Orders = currentPageOrders;
                model.PageSize = pageSize;
                model.PageIndex = pageIndex;
                model.TotalNumberOfOrders = orders.Count;
                model.NumberOfPages = numberOfPages;
                model.HasPrevPage = HasPreviousPage();
                model.HasNextPage = HasNextPage();
            }
        }
    }
}