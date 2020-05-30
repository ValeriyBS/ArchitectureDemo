using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Shared
{
    internal static class GetDbContextOptions
    {
        public static DbContextOptions<DatabaseContext> Execute()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();
            var connection = configuration.GetConnectionString("DefaultConnection");

            var options = new DbContextOptionsBuilder<DatabaseContext>()
                .UseSqlServer(connection)
                .Options;
            return options;
        }
    }
}
