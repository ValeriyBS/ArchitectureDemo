using System.Collections.Generic;
using Application.ShopItems.Queries;
using AutoFixture;
using Domain.Categories;
using Xunit;

namespace Application.Tests.ShopItems.Queries
{
    public sealed partial class ShopItemModelTests
    {
        public ShopItemModelTests()
        {
            var fixture = new Fixture();

            // client has a circular reference from AutoFixture point of view
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shopItemModel = new ShopItemModel();
            _category = new Category
            {
                Id = 1
            };

            fixture.Freeze<ShopItemModel>();
            _shopItemModelLeft = fixture.Create<ShopItemModel>();
            _shopItemModelRight = fixture.Create<ShopItemModel>();
        }

        private readonly Category _category;
        private readonly ShopItemModel _shopItemModel;
        private readonly ShopItemModel _shopItemModelLeft;
        private readonly ShopItemModel _shopItemModelRight;
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

        [Theory]
        [ClassData(typeof(ShopItemModelTestsData))]
        public void TestEqualsShouldReturnPredictedResultWhenComparingDifferentSetsOfObjects(ShopItemModel a,
            ShopItemModel b, bool expectedResult)
        {
            //Arrange

            //Act
            var result = a.Equals(b);

            //Assert
            Assert.Equal(expectedResult, result);
        }

        [Fact]
        public void TestEqualsOperatorShouldReturnTrueWhenComparingEqualObjects()
        {
            //Arrange
            //Act
            var result = _shopItemModelLeft == _shopItemModelRight;

            //Assert
            Assert.True(result);
        }


        [Fact]
        public void TestNotEqualsOperatorShouldReturnTrueWhenComparingNonEqualObjects()
        {
            //Arrange
            //Act
            var result = _shopItemModelLeft != _shopItemModelRight;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestSetAndGetCategory()
        {
            //Arrange
            //Act
            _shopItemModel.Category = _category;

            //Assert
            Assert.Equal(_category, _shopItemModel.Category);
        }

        [Fact]
        public void TestSetAndGetCategoryId()
        {
            //Arrange
            //Act
            _shopItemModel.CategoryId = CategoryId;

            //Assert
            Assert.Equal(CategoryId, _shopItemModel.CategoryId);
        }

        [Fact]
        public void TestSetAndGetId()
        {
            //Arrange
            //Act
            _shopItemModel.Id = Id;

            //Assert
            Assert.Equal(Id, _shopItemModel.Id);
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
        public void TestSetAndGetName()
        {
            //Arrange
            //Act
            _shopItemModel.Name = Name;

            //Assert
            Assert.Equal(Name, _shopItemModel.Name);
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
        public void TestSetAndGetShortDescription()
        {
            //Arrange
            //Act
            _shopItemModel.ShortDescription = ShortDescription;

            //Assert
            Assert.Equal(ShortDescription, _shopItemModel.ShortDescription);
        }

        [Fact]
        public void TestGetHashCode()
        {
            //Arrange
            var shopItemModelSet = new HashSet<ShopItemModel>(){_shopItemModel};

            //Act
            var result = shopItemModelSet.Contains(_shopItemModel);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsSameReferenceObject()
        {
            //Arrange
            var shopItemModelWrapper = (object)_shopItemModel;
            //Act
            var result = _shopItemModel.Equals(shopItemModelWrapper);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsObject()
        {
            //Arrange
            //Act
            var result = _shopItemModel.Equals(new object());

            //Assert
            Assert.False(result);
        }
    }
}