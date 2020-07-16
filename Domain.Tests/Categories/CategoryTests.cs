using System.Collections.Generic;
using System.Linq;
using AutoFixture;
using Domain.Categories;
using Domain.ShopItems;
using Xunit;

namespace Domain.Tests.Categories
{
    public class CategoryTests
    {
        private readonly Category _category;
        private readonly List<ShopItem> _shopItems;
        private readonly Category _categoryLeft;
        private readonly Category _categoryRight;
        private const int Id = 1;
        private const string Name = "testName";
        private const string Description = "testDescription";

        public CategoryTests()
        {
            _category = new Category();

            var fixture = new Fixture();

            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _shopItems = fixture.CreateMany<ShopItem>().ToList();

            fixture.Freeze<Category>();
            _categoryLeft = fixture.Create<Category>();
            _categoryRight = fixture.Create<Category>();
        }

        [Fact]
        public void TestSetGetName()
        {
            //Arrange
            //Act
            _category.Name = Name;

            //Assert
            Assert.Equal(Name,_category.Name);

        }

        [Fact]
        public void TestSetGetDescription()
        {
            //Arrange
            //Act
            _category.Description = Description;

            //Assert
            Assert.Equal(Description, _category.Description);

        }

        [Fact]
        public void TestSetGetShopItems()
        {
            //Arrange
            //Act
            _category.ShopItems = _shopItems;

            //Assert
            Assert.Equal(_shopItems, _category.ShopItems);

        }

        [Fact]
        public void TestSetGetId()
        {
            //Arrange
            //Act
            _category.Id = Id;

            //Assert
            Assert.Equal(Id, _category.Id);

        }

        [Fact]
        public void TestOperatorEqualTo()
        {
            //Arrange
            //Act
            var result = _categoryLeft == _categoryRight;

            //Assert
            Assert.True(result);

        }

        [Fact]
        public void TestOperatorNotEqualTo()
        {
            //Arrange
            //Act
            var result = _categoryLeft != _categoryRight;

            //Assert
            Assert.False(result);

        }

        [Fact]
        public void TestGetHashCode()
        {
            //Arrange
            var categorySet = new HashSet<Category> {_categoryLeft};

            //Act
            var result = categorySet.Contains(_categoryLeft);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsSameReferenceObject()
        {
            //Arrange
            var customerWrapper = (object)_categoryRight;
            //Act
            var result = _categoryRight.Equals(customerWrapper);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void TestEqualsObject()
        {
            //Arrange
            //Act
            var result = _categoryRight.Equals(new object());

            //Assert
            Assert.False(result);
        }
    }
}
