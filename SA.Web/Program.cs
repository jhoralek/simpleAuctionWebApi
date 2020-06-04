using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;

namespace SA.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Run();
        }

        public static IWebHost CreateWebHostBuilder(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddCommandLine(args)
                .Build();

            return WebHost.CreateDefaultBuilder(args)
                  .UseConfiguration(config)
                  .UseKestrel()
                  .UseWebRoot("wwwroot")
                  .UseUrls("http://*:5000")
                  .UseIISIntegration()
                  .UseStartup<Startup>()
                  .Build();
        }
    }
}
