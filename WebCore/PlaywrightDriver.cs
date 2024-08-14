using Microsoft.Playwright;
using OpenQA.Selenium;

namespace WebCore;

public class PlaywrightDriver: IWebDriverWrapper
{
        public IPage Page { get; private set; }
        private IBrowser _browser;
        private IBrowserContext _context;
        public TimeSpan DefaultTimeout { get; set; } = TimeSpan.FromSeconds(30);

        // Constructor accepting a browser name
        public PlaywrightDriver(string browserName)
        {
            Initialize(browserName);
        }

        private void Initialize(string browserName)
        {
            var playwright = Playwright.CreateAsync().GetAwaiter().GetResult();

            switch (browserName.ToUpper())
            {
                case "CHROME":
                    _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).GetAwaiter().GetResult();
                    break;
                case "CHROME_HEADLESS":
                    _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).GetAwaiter().GetResult();
                    break;
                case "FIREFOX":
                    _browser = playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).GetAwaiter().GetResult();
                    break;
                case "FIREFOX_HEADLESS":
                    _browser = playwright.Firefox.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true }).GetAwaiter().GetResult();
                    break;
                case "EDGE":
                    _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false, Channel = "msedge" }).GetAwaiter().GetResult();
                    break;
                case "EDGE_HEADLESS":
                    _browser = playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true, Channel = "msedge" }).GetAwaiter().GetResult();
                    break;
                case "SAFARI":
                    _browser = playwright.Webkit.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false }).GetAwaiter().GetResult();
                    break;
                default:
                    throw new ArgumentException($"Unsupported browser: {browserName}");
            }

            _context = _browser.NewContextAsync().GetAwaiter().GetResult();
            Page = _context.NewPageAsync().GetAwaiter().GetResult();
        }

        public void NavigateToUrl(string url)
        {
            Page.GotoAsync(url).GetAwaiter().GetResult();
        }

        public void Quit()
        {
            _browser.CloseAsync().GetAwaiter().GetResult();
        }

        public void Click()
        {
             Page.Locator("//button").ClickAsync();
        }

        public void EnterText()
        {
            throw new NotImplementedException();
        }

        public void GetAttribute()
        {
            throw new NotImplementedException();
        }

        // Add other methods as needed...
    }