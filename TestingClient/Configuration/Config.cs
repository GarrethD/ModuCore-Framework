using TestingClient.Enums;

namespace TestingClient.Configuration;

public class Config
{
        // Default values for local testing
        private static readonly DriverType DefaultDriver = DriverType.Selenium;
        private static readonly BrowserType DefaultBrowser = BrowserType.Chrome;
        private static readonly Url DefaultURL = Url.ExamplePage;

        // Default user and device settings for local testing
        private static readonly string DefaultUser = "User1";
        private static readonly string DefaultDevice = "Pixel6";

        // Method to get the driver type (Selenium or Playwright)
        public static DriverType GetDriverType(string driverTypeKey = "DRIVER")
        {
            string value = Environment.GetEnvironmentVariable(driverTypeKey);
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Driver was not selected. Default driver will now launch: {DefaultDriver}");
                return DefaultDriver;
            }

            if (Enum.TryParse(value, true, out DriverType driverType))
            {
                Console.WriteLine($"Using {driverType} driver for automated tests");
                return driverType;
            }
            else
            {
                Console.WriteLine($"Invalid driver type specified. Default driver will now launch: {DefaultDriver}");
                return DefaultDriver;
            }
        }

        // Method to get the browser type
        public static BrowserType GetBrowserType(string browserTypeKey = "BROWSER")
        {
            string value = Environment.GetEnvironmentVariable(browserTypeKey);
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Browser was not selected. Default browser will now launch: {DefaultBrowser}");
                return DefaultBrowser;
            }

            if (Enum.TryParse(value, true, out BrowserType browserType))
            {
                Console.WriteLine($"Using {browserType} browser for automated tests");
                return browserType;
            }
            else
            {
                Console.WriteLine($"Invalid browser type specified. Default browser will now launch: {DefaultBrowser}");
                return DefaultBrowser;
            }
        }

        // Method to get the environment URL
        public static string GetEnvironmentUrl(string urlKey = "URL")
        {
            string value = Environment.GetEnvironmentVariable(urlKey);
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"URL was not selected. Default URL will now be used: {DefaultURL.GetUrl()}");
                return DefaultURL.GetUrl();
            }

            Console.WriteLine($"Using {value} URL for automated tests");
            return value;
        }

        // Method to get the user
        public static string GetUser(string userKey = "USER")
        {
            string value = Environment.GetEnvironmentVariable(userKey);
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"User was not selected. Default user will now be used: {DefaultUser}");
                return DefaultUser;
            }

            Console.WriteLine($"Using {value} user for automated tests");
            return value;
        }

        // Method to get the device
        public static string GetDevice(string deviceKey = "DEVICE")
        {
            string value = Environment.GetEnvironmentVariable(deviceKey);
            if (string.IsNullOrEmpty(value))
            {
                Console.WriteLine($"Device was not selected. Default device will now be used: {DefaultDevice}");
                return DefaultDevice;
            }

            Console.WriteLine($"Using {value} device for automated tests");
            return value;
        }
    }