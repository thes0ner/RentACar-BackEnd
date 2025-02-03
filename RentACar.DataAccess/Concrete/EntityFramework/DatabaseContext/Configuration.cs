using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{

    // Provides configuration settings for the application
    public static class Configuration
    {
        // Gets the connection string for the database
        public static string ConnectionString
        {
            get
            {
                // Create a new instance of Configuration Manager.
                ConfigurationManager configurationManager = new ConfigurationManager();

                // Set the base path to the current directory containing the appsettings.json file.
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "RentACar.API"));

                // Add the appsettings.json file to the configuration manager.
                configurationManager.AddJsonFile("appsettings.json");

                // Return the connection string for the MSSQL database.
                return configurationManager.GetConnectionString("MSSQL");

            }
        }
    }
}
