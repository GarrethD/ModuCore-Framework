namespace TestingClient.Enums;

public enum Url
{
    ExamplePage,
    LoginPage,
    DashboardPage,
    SettingsPage,
    ReportsPage
}

public static class UrlExtensions
{
    public static string GetUrl(this Url url)
    {
        return url switch
        {
            Url.ExamplePage => "https://testpages.eviltester.com/styled/validation/input-validation.html",
            Url.LoginPage => "https://example.com/login",
            Url.DashboardPage => "https://example.com/dashboard",
            Url.SettingsPage => "https://example.com/settings",
            Url.ReportsPage => "https://example.com/reports",
            _ => throw new ArgumentOutOfRangeException(nameof(url), url, null)
        };
    }
}
