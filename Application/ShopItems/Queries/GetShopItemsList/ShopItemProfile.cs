using AutoMapper;
using Domain.ShopItems;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    internal class ShopItemProfile : Profile
    {
        public ShopItemProfile()
        {
            CreateMap<ShopItem, ShopItemModel>();
        }
    }
}
