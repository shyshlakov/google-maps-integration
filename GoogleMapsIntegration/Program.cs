using System.IO;
using Data;
using Data.Entities;
using Helper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace GoogleMapsIntegration
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)
                    .Build()
                    .MigrateDatabase<BaseDbContext>()
                    .Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseSerilog()
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}