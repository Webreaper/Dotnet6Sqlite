using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Dotnet6Sqlite
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();

                    try
                    {
                        Console.WriteLine("About to create SQLite DB...");

                        using TestContext db = new TestContext();
                        db.Database.EnsureCreated();

                        Console.WriteLine("Successfully created DB...");
                    }
                    catch( Exception ex )
                    {
                        Console.WriteLine($"Exception creating DB: {ex.Message}");
                        throw;
                    }
                });
    }
}
