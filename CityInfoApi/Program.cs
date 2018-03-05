using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace CityInfoApi
{
    public class Program
    {

        public static IConfiguration AppConfiguration { get; } = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        public static int Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(AppConfiguration)
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();


            Log.Verbose("TEST LEVEL Verbose");
            Log.Debug("TEST LEVEL Debug");
            Log.Information("TEST LEVEL Information");
            Log.Warning("TEST LEVEL Warning");
            Log.Error("TEST LEVEL Error");
            Log.Fatal("TEST LEVEL Fatal");


            Log.Debug($"Current BasePath taken from the DirectoryCurrentDirectory : {Directory.GetCurrentDirectory()}");
            Log.Debug($"Current BasePath taken from the Environment.CurrentDirectory : {Environment.CurrentDirectory}");


            try
            {

                Log.Information("Starting web host");
                BuildWebHost(args).Run();
                return 0;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "host terminated unexpectadly");
                return 1;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                   .UseSerilog()
                .Build();
    }
}
