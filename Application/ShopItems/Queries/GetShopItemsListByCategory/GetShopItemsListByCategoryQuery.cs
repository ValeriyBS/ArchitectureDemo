using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShopItems.Queries.GetShopItemsList;
using AutoMapper;

namespace Application.ShopItems.Queries.GetShopItemsListByCategory
{
    public class GetShopItemsListByCategoryQuery : IGetShopItemsListByCategoryQuery
    {
        private readonly IMapper _mapper;
        private readonly IShopItemRepository _shopItemRepository;

        public GetShopItemsListByCategoryQuery(IShopItemRepository shopItemRepository,
            IMapper mapper)
        {
            _shopItemRepository = shopItemRepository;
            _mapper = mapper;
        }

        public List<ShopItemModel> Execute(int categoryId)
        {
            return _shopItemRepository.GetAll().Where(c => c.CategoryId == categoryId)
                .Select(s => _mapper.Map<ShopItemModel>(s))
                .ToList();
        }
    }
}