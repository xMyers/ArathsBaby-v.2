using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ArathsBaby.Infrastructure;

namespace ArathsBaby.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //CreateWebHostBuilder(args).Build().Run();

            var host = CreateHostBuilder(args)
            .Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var loggerFactory = services.GetRequiredService<ILoggerFactory>();

                try
                {
                    EnsureDataStorageIsReadyAsync(services, loggerFactory);
                }
                catch (Exception ex)
                {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred seeding the DB.");
                }
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        static void EnsureDataStorageIsReadyAsync(IServiceProvider services,
                                                  ILoggerFactory loggerFactory)
        {
            var context = services.GetRequiredService<ArathsBabyContext>();
            ArathsBabyContextSeed.SeedAsync(context, loggerFactory)
                .Wait();
        }
    }
}
