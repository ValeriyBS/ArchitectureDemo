using System.Linq;
using Application.Categories.Queries.GetCategoryList;
using Application.Interfaces.Persistence;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoMapper;
using Domain.Categories;
using Moq;
using Xunit;

namespace Application.Tests.Categories.Queries.GetCategoryList
{
    public class GetCategoryListQueryTests
    {
        public GetCategoryListQueryTests()
        {
            var mapperConfiguration = new MapperConfiguration(cfg => { cfg.AddProfile(new CategoryProfile()); });
            _mapper = mapperConfiguration.CreateMapper();

            _fixture = new Fixture().Customize(new AutoMoqCustomization());

            // client has a circular reference from AutoFixture point of view
            _fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            _fixture.Behaviors.Add(new OmitOnRecursionBehavior());
        }

        private readonly IMapper _mapper;
        private readonly IFixture _fixture;

        [Fact]
        public void TestExecuteShouldReturnListOfCategories()
        {
            //Arrange
            const int expectedCount = 3;
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            var categoryModel = _fixture.CreateMany<Category>(expectedCount);

            mockCategoryRepository.Setup(c => c.GetAll()).Returns(categoryModel.AsQueryable());


            var sut = new GetCategoryListQuery(mockCategoryRepository.Object, _mapper);

            //Act
            var result = sut.Execute();
            //Assert
            Assert.Equal(expectedCount, result.Count);
        }
    }
}