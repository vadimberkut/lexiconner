﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Lexiconner.WebSpaTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            var builder = WebHost.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, configBuilder) =>
                {
                    // load env variables from .env file
                    string envFilePath = Path.Combine(Directory.GetCurrentDirectory(), ".env");
                    if (File.Exists(envFilePath))
                    {
                        DotNetEnv.Env.Load(envFilePath);
                    }

                    configBuilder.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                    configBuilder.AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json", optional: true, reloadOnChange: true);
                    configBuilder.AddEnvironmentVariables();
                });

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                builder.UseUrls($"http://localhost:5021;https://localhost:5022");
            }

            if (Environment.GetEnvironmentVariable("RUNTIME_ENV") == "heroku")
            {
                builder.UseUrls($"http://+:{Environment.GetEnvironmentVariable("PORT")}");
            }

            builder.UseStartup<Startup>();

            return builder;
        }
    }
}