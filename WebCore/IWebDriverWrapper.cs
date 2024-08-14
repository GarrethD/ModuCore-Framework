namespace WebCore;

public interface IWebDriverWrapper
{
    void NavigateToUrl(string url);
    void Quit();
    void Click();
    void EnterText();
    void GetAttribute();
}