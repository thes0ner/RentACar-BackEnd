using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{
    public class RentACarDbContextDesignTimeFactory : IDesignTimeDbContextFactory<RentACarDbContext>
    {
        public RentACarDbContext CreateDbContext(string[] args)
        {
            // Build configuration to read from appsettings.json
            var configuration = new ConfigurationBuilder()
                // Set the base path to the current directory.
                .SetBasePath(Directory.GetCurrentDirectory())
                // Load configuration from appsettings.json
                .AddJsonFile("appsettings.json")
                .Build();

            // Create options for RentACarDbContext
            var optionsBuilder = new DbContextOptionsBuilder<RentACarDbContext>();

            // Retrieve the connection string named 'MSSQL' from configuration.
            var connectionString = configuration.GetConnectionString("MSSQL");

            // Configure DbContext to use SQL Server with the retrieved connection string
            optionsBuilder.UseSqlServer(connectionString);

            // Return a new instance of RentACarDbContext with the configured options
            return new RentACarDbContext(optionsBuilder.Options);

        }
    }
}
