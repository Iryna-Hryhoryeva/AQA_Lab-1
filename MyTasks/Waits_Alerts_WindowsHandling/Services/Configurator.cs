using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.Configuration;

namespace Waits_Alerts_WindowsHandling.Services
{
    public static class Configurator
    {
        private static readonly Lazy<IConfiguration> s_configuration;
        public static IConfiguration Configuration => s_configuration.Value;
        public static string BrowserType => Configuration[nameof(BrowserType)];
        public static int WaitTimeout => int.Parse(Configuration[nameof(WaitTimeout)]);
        private static IConfigurationSection OnlinerTVs => Configuration.GetSection("Services:OnlinerTVs");
        public static string OnlinerBaseUrl => OnlinerTVs.GetSection("BaseUrl").Value;
        private static IConfigurationSection Herokuapp => Configuration.GetSection("Services:Herokuapp");
        public static string HerokuappBaseUrl => Herokuapp.GetSection("BaseUrl").Value;

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
