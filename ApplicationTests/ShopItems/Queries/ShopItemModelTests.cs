
using System.Linq;
using Application.ShopItems.Queries;
using Application.ShopItems.Queries.GetShopItemsList;
using AutoFixture;
using Domain.Categories;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Xunit;

namespace Application.Tests.ShopItems.Queries
{
    public class ShopItemModelTests
    {
        

        public ShopItemModelTests()
        {
            _fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shopItemModel = new ShopItemModel();
            _category = new Category()
            {
                Id = 1
            };
        }

        private readonly Category _category;
        private readonly ShopItemModel _shopItemModel;
        private readonly Fixture _fixture;
        private const int CategoryId = 1;
        private const int Id = 1;
        private const string ImageThumbnailUrl = "testUrl";
        private const string ImageUrl = "testImage";
        private const bool InStock = true;
        private const string LongDescription = "testLongDescription";
        private const string ShortDescription = "testShortDescription";
        private const string Name = "testName";
        private const string Notes = "testNotes";
        private const decimal Price = 1.0m;

       [Fact]
        public void TestSetAndGetName()
        {
            //Arrange
            //Act
            _shopItemModel.Name = Name;

            //Assert
            Assert.Equal(Name,_shopItemModel.Name);
        }

        [Fact]
        public void TestSetAndGetId()
        {
            //Arrange
            //Act
            _shopItemModel.Id = Id;

            //Assert
            Assert.Equal(Id,_shopItemModel.Id);
        }

        [Fact]
        public void TestSetAndGetCategoryId()
        {
            //Arrange
            //Act
            _shopItemModel.CategoryId = CategoryId;

            //Assert
            Assert.Equal(CategoryId,_shopItemModel.CategoryId);
        }

        [Fact]
        public void TestSetAndGetCategory()
        {
            //Arrange
            //Act
            _shopItemModel.Category = _category;

            //Assert
            Assert.Equal(_category,_shopItemModel.Category);
        }

        [Fact]
        public void TestSetAndGetImageThumbnailUrl()
        {
            //Arrange
            //Act
            _shopItemModel.ImageThumbnailUrl = ImageThumbnailUrl;

            //Assert
            Assert.Equal(ImageThumbnailUrl, _shopItemModel.ImageThumbnailUrl);
        }

        [Fact]
        public void TestSetAndGetImageUrl()
        {
            //Arrange
            //Act
            _shopItemModel.ImageUrl = ImageUrl;

            //Assert
            Assert.Equal(ImageUrl, _shopItemModel.ImageUrl);
        }

        [Fact]
        public void TestSetAndGetInStock()
        {
            //Arrange
            //Act
            _shopItemModel.InStock = InStock;

            //Assert
            Assert.Equal(InStock, _shopItemModel.InStock);
        }

        [Fact]
        public void TestSetAndGetLongDescription()
        {
            //Arrange
            //Act
            _shopItemModel.LongDescription = LongDescription;

            //Assert
            Assert.Equal(LongDescription, _shopItemModel.LongDescription);
        }

        [Fact]
        public void TestSetAndGetShortDescription()
        {
            //Arrange
            //Act
            _shopItemModel.ShortDescription = ShortDescription;

            //Assert
            Assert.Equal(ShortDescription, _shopItemModel.ShortDescription);
        }

        [Fact]
        public void TestSetAndGetNotes()
        {
            //Arrange
            //Act
            _shopItemModel.Notes = Notes;

            //Assert
            Assert.Equal(Notes, _shopItemModel.Notes);
        }

        [Fact]
        public void TestSetAndGetPrice()
        {
            //Arrange
            //Act
            _shopItemModel.Price = Price;

            //Assert
            Assert.Equal(Price, _shopItemModel.Price);
        }

        [Fact]
        public void TestEqualsOperatorReturnsTrueWhenComparingEqualObjects()
        {
            //Arrange
            _fixture.Freeze<ShopItemModel>();
            var shopItemModel1 = _fixture.Create<ShopItemModel>();
            var shopItemModel2 = _fixture.Create<ShopItemModel>();

            //Act
            var result = shopItemModel1 == shopItemModel2;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsReturnsTrueWhenComparingEqualObjects()
        {
            //Arrange
            _fixture.Freeze<ShopItemModel>();
            var shopItemModel1 = _fixture.Create<ShopItemModel>();
            var shopItemModel2 = _fixture.Create<ShopItemModel>();

            //Act
            var result = shopItemModel1.Equals(shopItemModel2);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestNotEqualsOperatorReturnsTrueWhenComparingNonEqualObjects()
        {
            //Arrange
            var shopItemModel1 = _fixture.Create<ShopItemModel>();
            var shopItemModel2 = _fixture.Create<ShopItemModel>();

            //Act
            var result = shopItemModel1 != shopItemModel2;

            //Assert
            Assert.True(result);
        }

    }
}
