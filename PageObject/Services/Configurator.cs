using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace PageObject.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;
        public static string BrowserType => Configuration[nameof(BrowserType)];
        public static int WaitTimeoutInMinutes => int.Parse(Configuration[nameof(WaitTimeoutInMinutes)]);
        public static IConfigurationSection SauceDemoWebsite => Configuration.GetSection("Services:SauceDemoWebsite");
        public static string BaseUrl => SauceDemoWebsite.GetSection("BaseUrl").Value;
        public static IConfigurationSection Users => SauceDemoWebsite.GetSection("Users");
        public static string Username => Users.GetSection("Username").Value;
        public static List<IConfigurationSection> ValidUsernames => Users.GetSection("ValidUsernames").GetChildren().ToList();
        public static string Password => SauceDemoWebsite.GetSection("Password").Value;
        public static IConfigurationSection Checkout => SauceDemoWebsite.GetSection("Checkout");
        public static string FirstName => Checkout.GetSection("FirstName").Value;
        public static string LastName => Checkout.GetSection("LastName").Value;
        public static string PostalCode => Checkout.GetSection("PostalCode").Value;

        static Configurator()
        {
            s_configuration = new Lazy<IConfiguration>(BuildConfiguration);
        }

        private static IConfiguration BuildConfiguration()
        {
            var basePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var builder = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile($"Data{Path.DirectorySeparatorChar}appsettings.json");

            var appSettingFiles = Directory.EnumerateFiles(basePath, "appsettings.*.json");

            foreach (var appSettingFile in appSettingFiles)
            {
                builder.AddJsonFile(appSettingFile);
            }

            return builder.Build();
        }
    }
}
