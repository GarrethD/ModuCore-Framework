using TestingClient.Configuration;
using TestingClient.Enums;
using WebCore;

namespace TestingClient.Tests.Web;

public class SeleniumDriverTest
{
    private SeleniumDriver _seleniumDriver;
    private string url;

    [SetUp]
    public void SetUp()
    {
        var browserType = Config.GetBrowserType();
        url = Config.GetEnvironmentUrl();
        _seleniumDriver = new SeleniumDriver(browserType.ToString());
        Console.WriteLine("Setup Completed");
    }

    [Test]
    public void ExampleTest()
    {
        _seleniumDriver.NavigateToUrl(url);
        Console.WriteLine("Test completed");
    }

    [TearDown]
    public void TearDown()
    {
        _seleniumDriver?.Quit();
    }
}