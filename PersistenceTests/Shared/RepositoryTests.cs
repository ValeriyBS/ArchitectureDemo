using Domain.Categories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Persistence.Shared;
using Xunit;

namespace Persistence.Tests.Shared
{
    public class RepositoryTests
    {
        private readonly DbContextOptions<DatabaseContext> _options;
        public RepositoryTests()
        {
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder { DataSource = ":memory:" };
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            _options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(connection)
                .Options;
        }
        [Fact]
        public void TestGetAllShouldReturnAllEntities()
        {
            //Arrange
             var expectedCategory = new Category()
             {
                 Id = 4,
                 Name = "Test"
             };

             using (var context = new DatabaseContext(_options))
             {
                 context.Database.OpenConnection();
                 context.Database.EnsureCreated();

                 context.Categories.Add(new Category()
                 {
                     Id = 4,
                     Name = "Test"
                 });

                 context.SaveChanges();
             }


             using (var context = new DatabaseContext(_options))
             {
                 var categoryRepository = new Repository<Category>(context);

                 //Act

                 var result = categoryRepository.GetAll();

                 //Assert

                 Assert.Contains(expectedCategory, result);
             }

        }

        [Fact]
        public void GetShouldReturnEntityWithProvidedId()
        {
            //Arrange
            const int testCategoryId = 5;
            const int expectedCategoryId = 5;

            var expectedCategory = new Category()
            {
                Id = expectedCategoryId,
                Name = "Test"
            };

            using (var context = new DatabaseContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Categories.Add(new Category()
                {
                    Id = testCategoryId,
                    Name = "Test"
                });

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(_options))
            {
                var categoryRepository = new Repository<Category>(context);

                //Act

                var result = categoryRepository.Get(testCategoryId);

                //Assert

                Assert.Equal(expectedCategory, result);
            }
        }

        [Fact]
        public void RemoveShouldRemoveEntityWithProvidedId()
        {
            //Arrange
            const int testCategoryId = 5;
            const int expectedCategoryId = 5;

            var expectedCategory = new Category()
            {
                Id = expectedCategoryId,
                Name = "Test"
            };

            using (var context = new DatabaseContext(_options))
            {
                context.Database.OpenConnection();
                context.Database.EnsureCreated();

                context.Categories.Add(new Category()
                {
                    Id = testCategoryId,
                    Name = "Test"
                });

                context.SaveChanges();
            }

            using (var context = new DatabaseContext(_options))
            {
                var categoryRepository = new Repository<Category>(context);

                //Act
                var categoryToRemove = categoryRepository.Get(testCategoryId);
                categoryRepository.Remove(categoryToRemove);
                context.SaveChanges();


                var result = categoryRepository.GetAll();


                //Assert

                Assert.DoesNotContain(expectedCategory, result);
            }
        }


    }
}
