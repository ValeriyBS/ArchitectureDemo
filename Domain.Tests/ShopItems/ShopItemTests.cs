using System.Collections.Generic;
using AutoFixture;
using Domain.Categories;
using Domain.ShopItems;
using Tests.Core.AutoFixture;
using Xunit;

namespace Domain.Tests.ShopItems
{
    public class ShopItemTests
    {
        public ShopItemTests()
        {
            _shopItem = new ShopItem();

            var fixture = new OmitRecursionFixture();

            _category = fixture.Create<Category>();

            fixture.Freeze<ShopItem>();
            _shopItemLeft = fixture.Create<ShopItem>();
            _shopItemRight = fixture.Create<ShopItem>();
        }

        private readonly ShopItem _shopItem;
        private readonly Category _category;
        private readonly ShopItem _shopItemLeft;
        private readonly ShopItem _shopItemRight;
        private const string Name = "testName";
        private const string ShortDescription = "testShortDescr";
        private const string LongDescription = "testLongDescr";
        private const string ImageUrl = "testImageUrl";
        private const string ImageThumbnailUrl = "testImageThumbNailUrl";
        private const string Notes = "testNotes";
        private const decimal Price = 1.1m;
        private const bool InStock = true;
        private const int CategoryId = 1;
        private const int Id = 2;

        [Fact]
        public void TestEqualsObject()
        {
            //Arrange
            //Act
            var result = _shopItem.Equals(new object());

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestEqualsSameReferenceObject()
        {
            //Arrange
            var categoryWrapper = (object) _shopItem;
            //Act
            var result = _shopItem.Equals(categoryWrapper);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestGetHashCode()
        {
            //Arrange
            var customerSet = new HashSet<ShopItem> {_shopItem};

            //Act
            var result = customerSet.Contains(_shopItem);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestOperatorEqualTo()
        {
            //Arrange
            //Act
            var result = _shopItemLeft == _shopItemRight;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestOperatorNotEqualTo()
        {
            //Arrange
            //Act
            var result = _shopItemLeft != _shopItemRight;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestSetGetCategory()
        {
            //Arrange
            //Act
            _shopItem.Category = _category;

            //Assert
            Assert.Equal(_category, _shopItem.Category);
        }

        [Fact]
        public void TestSetGetCategoryId()
        {
            //Arrange
            //Act
            _shopItem.CategoryId = CategoryId;

            //Assert
            Assert.Equal(CategoryId, _shopItem.CategoryId);
        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _shopItem.Id = Id;

            //Assert
            Assert.Equal(Id, _shopItem.Id);
        }

        [Fact]
        public void TestSetGetImageThumbnailUrl()
        {
            //Arrange
            //Act
            _shopItem.ImageThumbnailUrl = ImageThumbnailUrl;

            //Assert
            Assert.Equal(ImageThumbnailUrl, _shopItem.ImageThumbnailUrl);
        }

        [Fact]
        public void TestSetGetImageUrl()
        {
            //Arrange
            //Act
            _shopItem.ImageUrl = ImageUrl;

            //Assert
            Assert.Equal(ImageUrl, _shopItem.ImageUrl);
        }

        [Fact]
        public void TestSetGetInStock()
        {
            //Arrange
            //Act
            _shopItem.InStock = InStock;

            //Assert
            Assert.Equal(InStock, _shopItem.InStock);
        }

        [Fact]
        public void TestSetGetLongDescription()
        {
            //Arrange
            //Act
            _shopItem.LongDescription = LongDescription;

            //Assert
            Assert.Equal(LongDescription, _shopItem.LongDescription);
        }

        [Fact]
        public void TestSetGetName()
        {
            //Arrange
            //Act
            _shopItem.Name = Name;

            //Assert
            Assert.Equal(Name, _shopItem.Name);
        }

        [Fact]
        public void TestSetGetNotes()
        {
            //Arrange
            //Act
            _shopItem.Notes = Notes;

            //Assert
            Assert.Equal(Notes, _shopItem.Notes);
        }

        [Fact]
        public void TestSetGetPrice()
        {
            //Arrange
            //Act
            _shopItem.Price = Price;

            //Assert
            Assert.Equal(Price, _shopItem.Price);
        }

        [Fact]
        public void TestSetGetShortDescription()
        {
            //Arrange
            //Act
            _shopItem.ShortDescription = ShortDescription;

            //Assert
            Assert.Equal(ShortDescription, _shopItem.ShortDescription);
        }
    }
}