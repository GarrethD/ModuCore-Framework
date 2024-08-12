using TestingClient.Configuration;
using TestingClient.Enums;
using WebCore;

namespace TestingClient.Tests.Web;

public class PlaywrightDriverTest
{
    private PlaywrightDriver _playwrightDriver;
    private string url;

    [SetUp]
    public void SetUp()
    {
        var browserType = Config.GetBrowserType();
        url = Config.GetEnvironmentUrl();
        _playwrightDriver = new PlaywrightDriver(browserType.ToString());
        Console.WriteLine("Setup Completed");
    }

    [Test]
    public void ExampleTest()
    {
        _playwrightDriver.NavigateToUrl(url);
        Console.WriteLine("Test completed");
    }

    [TearDown]
    public void TearDown()
    {
        _playwrightDriver?.Quit();
    }
}