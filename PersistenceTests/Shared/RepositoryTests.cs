using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMoqCore;
using Domain.Categories;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
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
            var connectionStringBuilder =
                new SqliteConnectionStringBuilder {DataSource = ":memory:"};
            var connection = new SqliteConnection(connectionStringBuilder.ToString());

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlite(connection)
                .Options;


            using var context = new DatabaseContext(options);
            context.Database.OpenConnection();
            context.Database.EnsureCreated();

            var category = new Category()
            {
                Id = 4,
                Name = "Test"
            };


            context.Categories.Add(category);

            context.SaveChanges();
         
            var categoryRepository = new Repository<Category>(context);
           


            //Act

            var result = categoryRepository.GetAll();

            //Assert

            Assert.Contains(category,result);

        }
    }
}
