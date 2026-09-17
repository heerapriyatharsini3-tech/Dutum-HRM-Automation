using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestProject1.Drivers
{
    public class DriverFactory
    {
        private static ThreadLocal<IWebDriver> driver = new ThreadLocal<IWebDriver>();


        public static IWebDriver InitDriver()
        {
            ChromeOptions options = new ChromeOptions();

            // Browser options
            options.AddArgument("--start-maximized");
            options.AddArgument("--disable-notifications");

            driver.Value = new ChromeDriver(options);

            return driver.Value!;
        }
        public static IWebDriver GetDriver()
        {
            return driver.Value;
        }
        public static void QuitDriver()
        {
            if (driver.Value != null)
            {
                driver.Value.Quit();
                driver.Value.Dispose();
                driver.Value = null;
            }
        }
    }
}