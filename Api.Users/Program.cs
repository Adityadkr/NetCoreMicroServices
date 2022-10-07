using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Users
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
                })
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    config.AddJsonFile("appsettings.json");
                    config.AddJsonFile(Path.GetFullPath(Path.Combine(@"Shared/SharedSettings." + hostingContext.HostingEnvironment.EnvironmentName + ".json")));
                    //config.AddJsonFile(Path.GetFullPath(Path.Combine(@"../" + "SharedSettings." + hostingContext.HostingEnvironment.EnvironmentName + ".json")));
                });
    }
}
