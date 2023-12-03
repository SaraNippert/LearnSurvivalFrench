using System;
using System.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace Learn_French_App
{
    public class Program
    {
        static void Main(string[] args)
        {
            //// Get the connection string from the appsettings.json file
            //IConfigurationBuilder builder = new ConfigurationBuilder()
            //    .SetBasePath(Directory.GetCurrentDirectory())
            //    .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            //IConfigurationRoot configuration = builder.Build();

            //string connectionString = configuration.GetConnectionString("MoviesDb");

            UserInterface ui = new UserInterface();
            ui.Run();
        }
    }
}
