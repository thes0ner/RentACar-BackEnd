using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{

    // Provides configuration settings for the application
    public static class Configuration
    {

        // Property to retrieve the database connection string
        public static string ConnectionString
        {
            get
            {

                // Set up ConfigurationBuilder to load settings from appsettings.json
                var configuration = new ConfigurationBuilder()
                    //Set base path for the configuration file.
                    .SetBasePath(AppContext.BaseDirectory)
                    //Load JSON file (recuired, auto-reload on changes)
                    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                    .Build();

                // Retrieve and return the connection string
                return configuration.GetConnectionString("MSSQL");

            }
        }


    }
}
