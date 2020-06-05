using Domain.Categories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;
using Xunit;

namespace Persistence.Tests.Shared
{
    public class RepositoryTests
    {
        [Fact]
        public void TestGetAllShouldReturnAllEntities()
        {
            //Arrange
             var expectedCategory = new Category()
             {
                 Id = 4,
                 Name = "Test"
             };


            var connectionStringBuilder =
                new SqliteConnectionStringBuilder {DataSource = ":memory:"};
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(connection)
                .Options;


            using var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            context.Categories.Add(new Category()
            {
                Id = 4,
                Name = "Test"
            });

            context.SaveChanges();
         
            var categoryRepository = new Repository<Category>(context);
           


            //Act

            var result = categoryRepository.GetAll();

            //Assert

            Assert.Contains(expectedCategory,result);

        }
    }
}
