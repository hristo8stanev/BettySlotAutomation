using BettySlotAutomation.Constants;
using BettySlotAutomation.Core.Interfaces;
using BettySlotAutomation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System.Collections.ObjectModel;

namespace BettySlotAutomation.Core.Utilities;

public class DriverAdapter : IDriver
{
    private IWebDriver _webDriver;
    private WebDriverWait _webDriverWait;
    public string Url => _webDriver.Url;
    public string Title => _webDriver.Title;

    public void Start(BrowserType browser)
    {
        switch (browser)
        {
            case BrowserType.Chrome:
                _webDriver = new ChromeDriver();
                break;
            case BrowserType.ChromeHeadless:
                ChromeOptions chromeOptions = new ChromeOptions();
                chromeOptions.AddArgument("--headless");
                _webDriver = new ChromeDriver(chromeOptions);
                break;
            case BrowserType.Firefox:
                _webDriver = new FirefoxDriver();
                break;
            case BrowserType.Edge:
                _webDriver = new EdgeDriver();
                break;
            case BrowserType.ChromeMobileIphone14ProMax:
                ChromeOptions iphoneOptions = new ChromeOptions();
                iphoneOptions.EnableMobileEmulation(BrowserConstants.IPhone14ProMax);
                _webDriver = new ChromeDriver(iphoneOptions);
                break;
            case BrowserType.ChromeMobileSamsungS20:
                ChromeOptions samsungOptions = new ChromeOptions();
                samsungOptions.EnableMobileEmulation(BrowserConstants.SamsungGalaxyS20Ultra);
                _webDriver = new ChromeDriver(samsungOptions);
                break;
            case BrowserType.ChromeMobileIpadPro:
                ChromeOptions ipadOptions = new ChromeOptions();
                ipadOptions.EnableMobileEmulation(BrowserConstants.IPadPro);
                _webDriver = new ChromeDriver(ipadOptions);
                break;

            default:
                throw new ArgumentOutOfRangeException(nameof(browser), browser, null);
        }

        _webDriver.Manage().Window.Maximize();
        _webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(BrowserConstants.LongTimeoutSeconds));
    }

    public void Quit()
    {
        _webDriver.Quit();
    }

    public void GoToUrl(string url)
    {
        Logger.Info($"Navigating to: {url}");
        _webDriver.Navigate().GoToUrl(url);
    }

    public IComponent FindComponent(By locator)
    {
        Logger.Info($"FindComponent: {locator}");
        IWebElement nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);
        ScrollIntoView(element);

        return element;
    }

    public IComponent FindExisting(By locator)
    {
        Logger.Info($"FindExisting: {locator}");
        IWebElement nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        return new ComponentAdapter(_webDriver, nativeWebElement, locator);
    }

    public List<IComponent> FindComponents(By locator)
    {
        ReadOnlyCollection<IWebElement> nativeWebElements = _webDriverWait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(locator));
        var elements = new List<IComponent>();

        foreach (var nativeWebElement in nativeWebElements)
        {
            IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);
            elements.Add(element);
        }

        return elements;
    }

    public void Refresh()
    {
        _webDriver.Navigate().Refresh();
    }
    public bool ComponentExists(IComponent component)
    {
        try
        {
            _webDriver.FindElement(component.Locator);

            return true;
        }
        catch
        {
            return false;
        }
    }

    public void ExecuteScript(string script, params object[] args)
    {
        ((IJavaScriptExecutor)_webDriver).ExecuteScript(script, args);
    }

    public void WaitForAjax()
    {
        _webDriverWait.Until(driver =>
        {
            var script = "return window.jQuery != undefined && jQuery.active == 0";
            return (bool)((IJavaScriptExecutor)driver).ExecuteScript(script);
        });
    }

    private void ScrollIntoView(IComponent element)
    {
        ExecuteScript("arguments[0].scrollIntoView({block: 'center'});", element.WrappedElement);
    }

    public IComponent WaitToBeClickable(By locator)
    {
        var nativeWebElement = _webDriverWait.Until(ExpectedConditions.ElementToBeClickable(locator));
        IComponent element = new ComponentAdapter(_webDriver, nativeWebElement, locator);

        ScrollIntoView(element);

        return element;
    }

    public IComponent FindInFrame(By locator)
    {
        _webDriver.SwitchTo().DefaultContent();
        var frame = _webDriverWait.Until(ExpectedConditions.ElementExists(By.TagName("iframe")));
        _webDriver.SwitchTo().Frame(frame);
        var element = _webDriverWait.Until(ExpectedConditions.ElementIsVisible(locator));
        return new ComponentAdapter(_webDriver, element, locator);
    }

    public IDriver SwitchToFrame(By locator)
    {
        var frame = _webDriverWait.Until(ExpectedConditions.ElementExists(locator));
        _webDriver.SwitchTo().Frame(frame);
        return this;
    }

    public IDriver SwitchToDefaultContent()
    {
        _webDriver.SwitchTo().DefaultContent();
        return this;
    }

    public IDriver SwitchToLastWindow()
    {
        Logger.Info("Switching to last window");
        _webDriver.SwitchTo().Window(_webDriver.WindowHandles.Last());
        return this;
    }

    public void WaitForPageLoad()
    {
        _webDriverWait.Until(driver =>
            ((IJavaScriptExecutor)driver).ExecuteScript("return document.readyState").Equals("complete"));
    }

    public void DeleteAllCookies()
    {
        _webDriver.Manage().Cookies.DeleteAllCookies();
    }

    public void AcceptCookies()
    {
        _webDriver.Manage().Cookies.AddCookie(new Cookie("cookieCompliancyAccepted", "1"));
        Refresh();
    }
}