using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
using AutoMapper;
using Domain.ShopItems;

[assembly:InternalsVisibleTo("Application.Tests")]
namespace Application.ShopItems.Queries
{
    [ExcludeFromCodeCoverage]
    internal class ShopItemProfile : Profile
    {
        public ShopItemProfile()
        {
            CreateMap<ShopItem, ShopItemModel>();
        }
    }
}
