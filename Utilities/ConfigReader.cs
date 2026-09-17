using Microsoft.Extensions.Configuration;

namespace TestProject1.Utilities
{
    public static class ConfigReader
    {
        private static IConfigurationRoot configuration;

        static ConfigReader()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("ConfigFile/appsettings.json", optional: false, reloadOnChange: true);

            configuration = builder.Build();
        }

        public static string BaseUrl => configuration["AppSettings:BaseUrl"];
        public static string QaURL => configuration["AppSettings:QaURL"];
    }
}