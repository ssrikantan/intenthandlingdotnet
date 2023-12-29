// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.
//
// Generated with EchoBot .NET Template version v4.17.1

using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.Extensions.Configuration;



namespace EchoBot
{
    public class Program
    {
        private readonly IConfiguration _configuration;
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config.SetBasePath(Directory.GetCurrentDirectory());
                config.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.ConfigureLogging((logging) =>
                {
                    logging.AddDebug();
                    logging.AddConsole();
                });
                webBuilder.UseStartup<Startup>();
            });
    }
}
