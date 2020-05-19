using System;
using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Domain.ShopItems;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public class GetShopItemsListQuery : IGetShopItemsListQuery
    {
        private readonly IShopItemRepository _shopItemRepository;

        public GetShopItemsListQuery(IShopItemRepository shopItemRepository)
        {
            _shopItemRepository = shopItemRepository;
        }
        public List<ShopItemsModel> Execute()
        {
            var shopItems =  _shopItemRepository.GetAll();
            var shopItemsModels = ShopItemsModelsMapping(shopItems);
            return shopItemsModels;
        }

       

        public List<ShopItemsModel> Execute(int categoryId)
        {
            return Execute().FindAll(c => c.Category.Id == categoryId);
        }

        public List<ShopItemsModel> Execute(string categoryName)
        {
            throw new NotImplementedException();
        }

        private static List<ShopItemsModel> ShopItemsModelsMapping(IQueryable<ShopItem> shopItems)
        {
            var shopItemsModels = shopItems.Select(s => new ShopItemsModel()
            {
                Name = s.Name,
                ShortDescription = s.ShortDescription,
                LongDescription = s.LongDescription,
                Price = s.Price,
                ImageUrl = s.ImageUrl,
                ImageThumbnailUrl = s.ImageThumbnailUrl,
                InStock = s.InStock,
                CategoryId = s.CategoryId,
                Category = s.Category,
                Notes = s.Notes,
                Id = s.Id
            }).ToList();
            return shopItemsModels;
        }
    }
}
