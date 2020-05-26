using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Interfaces.Persistence;
using Domain.ShopItems;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public class GetShopItemsListByCategoryQuery : IGetShopItemsListByCategoryQuery
    {
        private readonly IShopItemRepository _shopItemRepository;

        public GetShopItemsListByCategoryQuery(IShopItemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }

        public List<ShopItemsModel> Execute(int categoryId)
        {
            return _shopItemRepository.GetAll().Where(c => c.CategoryId == categoryId)
                .Select(s => ShopItemModelMapping(s))
                .ToList();
        }

        private static ShopItemsModel ShopItemModelMapping(ShopItem shopItem)
        {
            //var shopItemsModels = shopItems.Select(s => new ShopItemsModel()
            var shopItemModel = new ShopItemsModel()
            {
                Name = shopItem.Name,
                ShortDescription = shopItem.ShortDescription,
                LongDescription = shopItem.LongDescription,
                Price = shopItem.Price,
                ImageUrl = shopItem.ImageUrl,
                ImageThumbnailUrl = shopItem.ImageThumbnailUrl,
                InStock = shopItem.InStock,
                CategoryId = shopItem.CategoryId,
                Category = shopItem.Category,
                Notes = shopItem.Notes,
                Id = shopItem.Id
            };
            return shopItemModel;
        }
    }
}
