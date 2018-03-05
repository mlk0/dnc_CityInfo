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
        //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/hosting?tabs=aspnetcore2x
        //the following statements are identical with the default instantiation of the Configuration that needs to happen when calling
        //WebHost.CreateDefaultBuilder
        //then whay this is happening this early?
        //It's because the Serilig config was documented in this way.
        //and it looks like this is the earlies possible point when the BuildWebHost can be tracked with the generated exception if it fails.
        //since the Log.Logger needs to be assigned with something in order for the Serilog to be fully operational, the setup of the AppConfiguration
        //that usually happens in Startup is moved over here.
        //public static IConfiguration AppConfiguration { get; } = new ConfigurationBuilder()
            //.SetBasePath(Directory.GetCurrentDirectory())
            //.AddJsonFile("appsettingsL.json", optional: false, reloadOnChange: true)
            //.AddJsonFile($"appsettingsL.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production"}.json", optional: true)
            //.AddEnvironmentVariables()
            //.Build();

        public static int Main(string[] args)
        {
            //Log.Logger = new LoggerConfiguration()
                //.ReadFrom.Configuration(AppConfiguration)
                //.Enrich.FromLogContext()
                //.WriteTo.Console()
                //.CreateLogger();


            //Log.Verbose("TEST LEVEL Verbose");
            //Log.Debug("TEST LEVEL Debug");
            //Log.Information("TEST LEVEL Information");
            //Log.Warning("TEST LEVEL Warning");
            //Log.Error("TEST LEVEL Error");
            //Log.Fatal("TEST LEVEL Fatal");


            //Log.Debug($"Current BasePath taken from the DirectoryCurrentDirectory : {Directory.GetCurrentDirectory()}");
            //Log.Debug($"Current BasePath taken from the Environment.CurrentDirectory : {Environment.CurrentDirectory}");


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
        //https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.webhost.createdefaultbuilder?view=aspnetcore-2.0#Microsoft_AspNetCore_WebHost_CreateDefaultBuilder
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                   .UseSerilog()
                .Build();
    }
}
