using Microsoft.IdentityModel.Protocols;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.DataAccess.Concrete.EntityFramework.DatabaseContext
{
    public static class Configuration
    {
        public static string ConnectionString
        {
            get
            {
                ConfigurationManager configurationManager = new ConfigurationManager();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "RentACar.API"));
                configurationManager.AddJsonFile("appsettings.json");

                return configurationManager.GetConnectionString("MSSQL");

            }
        }
    }
}
