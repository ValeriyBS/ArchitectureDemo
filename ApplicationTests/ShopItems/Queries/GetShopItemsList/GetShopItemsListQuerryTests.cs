using System.Collections.Generic;
using System.Linq;
using Application.Interfaces.Persistence;
using Application.ShopItems.Queries;
using Application.ShopItems.Queries.GetShopItemsList;
using AutoFixture;
using AutoMapper;
using Domain.ShopItems;
using Moq;
using Xunit;

namespace Application.Tests.ShopItems.Queries.GetShopItemsList
{
    public class GetShopItemsListQueryTests
    {
        public GetShopItemsListQueryTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new ShopItemProfile()); });
            _mapper = mapperConfiguration.CreateMapper();

            var fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shopItems = fixture.CreateMany<ShopItem>(3).ToList();
        }

        private readonly IMapper _mapper;
        private readonly List<ShopItem> _shopItems;

        [Fact]
        public void TestExecuteShouldReturnListOfShopItemModel()
        {
            //Arrange
            var expectedResult = _shopItems.Select(s => _mapper.Map<ShopItemModel>(s)).ToList();

            var mockShopItemRepository = new Mock<IShopItemRepository>();

            mockShopItemRepository.Setup(s => s.GetAll()).Returns(_shopItems.AsQueryable);

            var sut = new GetShopItemsListQuery(mockShopItemRepository.Object, _mapper);


            //Act
            var result = sut.Execute();

            //Assert
            Assert.IsType<List<ShopItemModel>>(result);

            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestExecuteWithItemIdShouldReturnShopItemModelWithItemId()
        {
            //Arrange
            const int itemId = 2;

            _shopItems.Add(new ShopItem { Id = 2, Name = "testItemName2" });

            var expectedResult = _mapper.Map<ShopItemModel>(_shopItems.FirstOrDefault(s => s.Id == itemId));

            var mockShopItemRepository = new Mock<IShopItemRepository>();

            mockShopItemRepository.Setup(s => s.Get(itemId)).Returns(_shopItems.FirstOrDefault(s => s.Id == itemId));

            var sut = new GetShopItemsListQuery(mockShopItemRepository.Object, _mapper);


            //Act
            var result = sut.Execute(itemId);

            //Assert
            Assert.IsType<ShopItemModel>(result);

            Assert.Equal(expectedResult, result);
        }


    }
}