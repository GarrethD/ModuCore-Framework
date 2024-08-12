namespace WebCore;

public interface IWebDriverWrapper
{
    void NavigateToUrl(string url);
    void Quit();
}