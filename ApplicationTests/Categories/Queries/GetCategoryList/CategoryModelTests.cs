using Application.Categories.Queries.GetCategoryList;
using AutoFixture;
using Xunit;

namespace Application.Tests.Categories.Queries.GetCategoryList
{
    public class CategoryModelTests
    {
        public CategoryModelTests()
        {
            var fixture = new Fixture();
            _categoryModel = new CategoryModel();
            _id = fixture.Create<int>();
            _name = fixture.Create<string>();
            _description = fixture.Create<string>();
        }

        private readonly CategoryModel _categoryModel;
        private readonly int _id;
        private readonly string _name;
        private readonly string _description;

        [Fact]
        public void TestSetAndGetDescription()
        {
            //Arrange
            //Act
            _categoryModel.Description = _description;

            //Assert
            Assert.Equal(_description, _categoryModel.Description);
        }

        [Fact]
        public void TestSetAndGetId()
        {
            //Arrange
            //Act
            _categoryModel.Id = _id;

            //Assert
            Assert.Equal(_id, _categoryModel.Id);
        }

        [Fact]
        public void TestSetAndGetName()
        {
            //Arrange
            //Act
            _categoryModel.Name = _name;

            //Assert
            Assert.Equal(_name, _categoryModel.Name);
        }
    }
}