using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Support.UI;

namespace WebCore;

public class SeleniumDriver
{
    public IWebDriver WebDriver { get; private set; }
    private WebDriverWait _wait;
    public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(30);
    public TimeSpan DefaultPollInterval { get; set; } = TimeSpan.FromSeconds(1);
    
    // Constructor accepting a browser name
    public SeleniumDriver(string browserName)
    {
        switch (browserName.ToUpper())
        {
            case "CHROME":
                InitializeChromeDriver();
                break;
            case "CHROME_HEADLESS":
                InitializeHeadlessChromeDriver();
                break;
            case "FIREFOX":
                InitializeFirefoxDriver();
                break;
            case "FIREFOX_HEADLESS":
                InitializeHeadlessFirefoxDriver();
                break;
            case "EDGE":
                InitializeEdgeDriver();
                break;
            case "EDGE_HEADLESS":
                InitializeHeadlessEdgeDriver();
                break;
            case "SAFARI":
                InitializeSafariDriver();
                break;
            default:
                throw new ArgumentException($"Unsupported browser: {browserName}");
        }
        ConfigureDriver();
    }

    private void InitializeChromeDriver()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        WebDriver = new ChromeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeHeadlessChromeDriver()
    {
        ChromeOptions options = new ChromeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");
        options.AddArgument("--disable-dev-shm-usage");
        WebDriver = new ChromeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeFirefoxDriver()
    {
        FirefoxOptions options = new FirefoxOptions();
        WebDriver = new FirefoxDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeHeadlessFirefoxDriver()
    {
        FirefoxOptions options = new FirefoxOptions();
        options.AddArgument("--headless");
        WebDriver = new FirefoxDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeEdgeDriver()
    {
        EdgeOptions options = new EdgeOptions();
        options.AddArgument("--no-sandbox");
        WebDriver = new EdgeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeHeadlessEdgeDriver()
    {
        EdgeOptions options = new EdgeOptions();
        options.AddArgument("--headless");
        options.AddArgument("--no-sandbox");
        WebDriver = new EdgeDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void InitializeSafariDriver()
    {
        SafariOptions options = new SafariOptions();
        WebDriver = new SafariDriver(options);
        WebDriver.Manage().Window.Maximize();
    }

    private void ConfigureDriver()
    {
        _wait = new WebDriverWait(WebDriver, DefaultTimeout)
        {
            PollingInterval = DefaultPollInterval
        };
    }

    public void NavigateToUrl(string url)
    {
        WebDriver.Navigate().GoToUrl(url);
    }

    public void Quit()
    {
        WebDriver.Quit();
    }

    // Add other methods as needed... 
}