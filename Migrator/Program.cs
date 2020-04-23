using Infrastructure.Data.EFCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace Migrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var environmentName = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

            if (string.IsNullOrEmpty(environmentName))
            {
                environmentName = EnvironmentPicker.Pick();
            }

            Console.WriteLine("Migrator Environment: ", environmentName);

            var builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory().Replace("\\bin\\Debug\\netcoreapp3.0", ""))
                //.SetBasePath("/Previous Content/Souce/webapp-clubeez/CM.Migrator/")

                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{environmentName}.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connectionString = configuration.GetConnectionString("Default");

            if (string.IsNullOrWhiteSpace(connectionString))
            {
                Console.WriteLine("Please set this variable to a connection string.");
                return;
            }

            var context = new DataContextFactory<DataContext>().Create(connectionString);

            using (var dbConn = context.Database.GetDbConnection())
            {
                Console.WriteLine($"This will migrate {dbConn.DataSource}\\{dbConn.Database}. Continue?");
                Console.WriteLine(context.Database.GetMigrations().Count() + " migration(s) found.");
                Console.WriteLine(context.Database.GetPendingMigrations().Count() + " to be applied.");
                try
                {
                    context.Database.Migrate();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Migration failed: " + e.Message);
                }
                Console.WriteLine("Done");
            }
        }
    }
}
