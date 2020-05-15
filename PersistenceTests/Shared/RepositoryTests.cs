using System;
using System.Collections.Generic;
using System.Text;
using AutoMoqCore;
using Domain.Categories;
using Moq;
using Persistence.Shared;
using Xunit;

namespace PersistenceTests.Shared
{
    public class RepositoryTests
    {
        [Fact]
        public void TestGetShouldReturnAllEntities()
        {
            //Arrange
            var mockDataBaseContext = new AutoMoqer();

            var category = new Category()
            {
                Id = 1,
                Name = "Men"
            };

            var inMemoryDatabase = new InMemoryDatabase<Category>(){category};

            //mockDataBaseContext.GetMock<Category>()
            //    .Setup(e => e.Set<Category>)
            //    .Returns();
            //var sut = new Repository<Category>(mockDataBaseContext.Object);

            //Act

            //var result = sut.GetAll();

            //Assert
        }
    }
}
