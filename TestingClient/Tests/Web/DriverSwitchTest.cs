using TestingClient.Configuration;
using TestingClient.Enums;
using WebCore;

namespace TestingClient.Tests.Web;

public class DriverSwitchTest
{
    private IWebDriverWrapper _driver;
    private string _url;

    [SetUp]
    public void SetUp()
    {
        var driverType = Config.GetDriverType();
        var browserType = Config.GetBrowserType();
        _url = Config.GetEnvironmentUrl();

        // Select the appropriate driver based on the configuration
        _driver = driverType switch
        {
            DriverType.Selenium => new SeleniumDriver(browserType.ToString()) as IWebDriverWrapper,
            DriverType.Playwright => new PlaywrightDriver(browserType.ToString()) as IWebDriverWrapper,
            _ => throw new ArgumentException($"Unsupported driver type: {driverType}")
        };

        Console.WriteLine("Setup Completed");
    }

    [Test]
    public void ExampleTest()
    {
        _driver.NavigateToUrl(_url);
        Console.WriteLine("Test completed");
    }

    [TearDown]
    public void TearDown()
    {
        _driver?.Quit();
    }
}