using System.Text;
using Domain.Orders;

namespace Application.Orders.ExtensionMethods
{
    public static class OrderExtensions
    {
        public static string? ToHtmlMessage(this Order order)
        {
            var htmlBuilder = new StringBuilder("");
            htmlBuilder.Append("<html>");
            htmlBuilder.Append("<head>");
            htmlBuilder.Append($"<h7> Order Ref:{order.Id}");
            htmlBuilder.Append($"<br/> Order placed: {order.OrderPlaced}</h7><br/><br/>");
            htmlBuilder.Append("</head>");
            htmlBuilder.Append("<body>");
            htmlBuilder.Append("<table class=\"table table-striped table-bordered\">");
            htmlBuilder.Append("<thead class=\"thead-dark\">");
            htmlBuilder.Append("<tr>");
            htmlBuilder.Append("<th scope = \"col\" class=\"text - center\">#</th>");
            htmlBuilder.Append("<th scope = \"col\" class=\"text-center\">Product Name</th>");
            htmlBuilder.Append("<th scope = \"col\" class=\"text-center\">Amount</th>");
            htmlBuilder.Append("<th scope = \"col\" class=\"text-right\">Price</th>");
            htmlBuilder.Append("</tr> ");
            htmlBuilder.Append("</thead>");
            htmlBuilder.Append("<tbody>");
            var i = 1;
            foreach (var orderDetail in order.OrderDetails)
            {
                htmlBuilder.Append("<tr>");
                htmlBuilder.Append($"<td class=\"text-center\">{i++}</td>");
                htmlBuilder.Append($"<td class=\"text-center\">{orderDetail.ShopItem.Name}</td>");
                htmlBuilder.Append($"<td class=\"text-center\">{orderDetail.Amount}</td>");
                htmlBuilder.Append($"<td class=\"text-right\">{orderDetail.Price * orderDetail.Amount:C}</td>");
                htmlBuilder.Append("</tr>");
            }

            htmlBuilder.Append("<tr>");
            htmlBuilder.Append("<td></td>");
            htmlBuilder.Append("<td></td>");
            htmlBuilder.Append("<td class=\"text-center\"><strong>Total</strong></td>");
            htmlBuilder.Append($"<td class=\"text-right\"><strong>{order.OrderTotal:C}</strong></td>");
            htmlBuilder.Append("</tr>");
            htmlBuilder.Append("</tbody>");
            htmlBuilder.Append("</table>");
            htmlBuilder.Append("</body>");
            htmlBuilder.Append("</html>");

            return htmlBuilder.ToString();
        }
    }
}