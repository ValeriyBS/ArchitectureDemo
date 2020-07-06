using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using AutoMapper;

namespace Application.ShopItems.Queries.GetShopItemsList
{
    public class GetShopItemsListQuery : IGetShopItemsListQuery
    {
        private readonly IMapper _mapper;
        private readonly IShopItemRepository _shopItemRepository;

        public GetShopItemsListQuery(IShopItemRepository shopItemRepository,
            IMapper mapper)
        {
            _shopItemRepository = shopItemRepository;
            _mapper = mapper;
        }

        public List<ShopItemModel> Execute()
        {
            var shopItems = _shopItemRepository.GetAll();
            var shopItemModels = shopItems.Select(s => _mapper.Map<ShopItemModel>(s));
            return shopItemModels.ToList();
        }


        public ShopItemModel Execute(int itemId)
        {
            var shopItem = _shopItemRepository.Get(itemId);
            return _mapper.Map<ShopItemModel>(shopItem);
        }
    }
}