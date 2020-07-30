using System.Collections.Generic;
using AutoFixture;
using Domain.ShopItems;
using Domain.ShoppingCartItems;
using Tests.Core.AutoFixture;
using Xunit;

namespace Domain.Tests.ShoppingCartItems
{
    public class ShoppingCartItemTests
    {
        public ShoppingCartItemTests()
        {
            _shoppingCartItem = new ShoppingCartItem();

            var fixture = new OmitRecursionFixture();

            _shopItem = fixture.Create<ShopItem>();

            fixture.Freeze<ShoppingCartItem>();
            _shoppingCartItemLeft = fixture.Create<ShoppingCartItem>();
            _shoppingCartItemRight = fixture.Create<ShoppingCartItem>();
        }

        private readonly ShoppingCartItem _shoppingCartItem;
        private readonly ShopItem _shopItem;
        private readonly ShoppingCartItem _shoppingCartItemLeft;
        private readonly ShoppingCartItem _shoppingCartItemRight;
        private const int ShopItemId = 1;
        private const int Amount = 2;
        private const int Id = 3;
        private const string ShoppingCartId = "testShoppingCartId";

        [Fact]
        public void TestEqualsObject()
        {
            //Arrange
            //Act
            var result = _shoppingCartItem.Equals(new object());

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestEqualsSameReferenceObject()
        {
            //Arrange
            var customerWrapper = (object) _shoppingCartItem;
            //Act
            var result = _shoppingCartItem.Equals(customerWrapper);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestGetHashCode()
        {
            //Arrange
            var categorySet = new HashSet<ShoppingCartItem> {_shoppingCartItem};

            //Act
            var result = categorySet.Contains(_shoppingCartItem);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestOperatorEqualTo()
        {
            //Arrange
            //Act
            var result = _shoppingCartItemLeft == _shoppingCartItemRight;

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestOperatorNotEqualTo()
        {
            //Arrange
            //Act
            var result = _shoppingCartItemLeft != _shoppingCartItemRight;

            //Assert
            Assert.False(result);
        }

        [Fact]
        public void TestSetGetAmount()
        {
            //Arrange
            //Act
            _shoppingCartItem.Amount = Amount;

            //Assert
            Assert.Equal(Amount, _shoppingCartItem.Amount);
        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _shoppingCartItem.Id = Id;

            //Assert
            Assert.Equal(Id, _shoppingCartItem.Id);
        }

        [Fact]
        public void TestSetGetShopItem()
        {
            //Arrange
            //Act
            _shoppingCartItem.ShopItem = _shopItem;

            //Assert
            Assert.Equal(_shopItem, _shoppingCartItem.ShopItem);
        }

        [Fact]
        public void TestSetGetShopItemId()
        {
            //Arrange
            //Act
            _shoppingCartItem.ShopItemId = ShopItemId;

            //Assert
            Assert.Equal(ShopItemId, _shoppingCartItem.ShopItemId);
        }

        [Fact]
        public void TestSetGetShoppingCartId()
        {
            //Arrange
            //Act
            _shoppingCartItem.ShoppingCartId = ShoppingCartId;

            //Assert
            Assert.Equal(ShoppingCartId, _shoppingCartItem.ShoppingCartId);
        }
    }
}