using BettySlotAutomation.Core.Interfaces;
using BettySlotAutomation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace BettySlotAutomation.Core.Utilities;

public class DriverAdapter : IDriver
{
    private const int WAIT_FOR_ELEMENT = 30;
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;
    public string Url => _webDriver.Url;

    public void Start(BrowserType browser)
    {
        switch (browser)
        {
            case BrowserType.CHROME:
                _webDriver = new ChromeDriver();
                break;
            case BrowserType.CHROME_HEADLESS:
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--headless");
                _webDriver = new ChromeDriver(chromeOptions);
                break;
            case BrowserType.FIREFOX:
                _webDriver = new FirefoxDriver();
                break;
            case BrowserType.EDGE:
                _webDriver = new EdgeDriver();
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriver.Manage().Window.Maximize();
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(WAIT_FOR_ELEMENT));
    }

    public void Quit()
    {
        _webDriver.Quit();
    }

    public void GoToUrl(string url)
    {
        _webDriver.Navigate().GoToUrl(url);
    }

    public void Refresh()
    {
        throw new NotImplementedException();
    }

    public void DeleteAllCookies()
    {
        _webDriver.Manage().Cookies.DeleteAllCookies();
    }

    public IComponent FindComponent(By locator)
    {
        throw new NotImplementedException();
    }

    public List<IComponent> FindComponents(By locator)
    {
        throw new NotImplementedException();
    }
}
