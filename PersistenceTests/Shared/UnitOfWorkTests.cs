using System;
using Moq;
using Persistence.Shared;
using Xunit;

namespace Persistence.Tests.Shared
{
    public class UnitOfWorkTests
    {
        [Fact]
        public void TestShouldSaveUnitOfWork()
        {
            //Arrange
            var mockDatabaseContext = new Mock<IDatabaseContext>();


            var sut = new UnitOfWork(mockDatabaseContext.Object);

            //Act
            sut.Save();

            //Assert
            mockDatabaseContext.Verify(d => d.Save(), Times.Once);
        }
    }
}