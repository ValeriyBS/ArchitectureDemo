using System.Diagnostics.CodeAnalysis;
using AutoMapper;
using Domain.OrderDetails;
using Domain.ShoppingCartItems;

namespace Application.Orders.Commands.CreateOrder.Factory
{
    [ExcludeFromCodeCoverage]
    internal class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<ShoppingCartItem, OrderDetail>()
                .ForMember(o => o.Price,
                    m => m
                        .MapFrom(c => c.ShopItem.Price));
        }
    }
}