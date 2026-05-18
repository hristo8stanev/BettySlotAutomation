using BettySlotAutomation.Constants;
using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace BettySlotAutomation.Core.Utilities;

public class ComponentAdapter : IComponent
{
    private readonly IWebDriver _webDriver;
    private readonly Actions _actions;
    private readonly IWebElement _webElement;
    private readonly By _by;
    public IWebElement WrappedElement { get; }
    public By Locator { get; }
    public string Text => _webElement?.Text;
    public bool? Enabled => _webElement?.Enabled;
    public bool? Displayed => _webElement?.Displayed;

    public ComponentAdapter(IWebDriver webDriver, IWebElement webElement, By by)
    {
        _webDriver = webDriver;
        _actions = new Actions(_webDriver);
        _webElement = webElement;
        _by = by;
        Locator = by;
        WrappedElement = webElement;
    }

    public void Click(bool waitToBeClickable = false)
    {
        Logger.Info($"Click: {_by}");

        if (waitToBeClickable)
        {
            WaitToBeClickable(_by);
        }

        _webElement?.Click();
    }

    public string GetAttribute(string attributeName)
    {
        return _webElement?.GetAttribute(attributeName);
    }

    public void TypeText(string text)
    {
        Logger.Info($"TypeText: '{text}' into {_by}");
        _webElement?.Clear();
        _webElement?.SendKeys(text);
    }

    public void Hover()
    {
        Logger.Info($"Hover: {_by}");
        _actions.MoveToElement(_webElement).Perform();
    }

    public IWebElement MoveToElement(IWebElement element)
    {
        _actions.MoveToElement(element).Perform();
        return element;
    }

    public void WaitToBeClickable(By by)
    {
        var webDriverWait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(BrowserConstants.LongTimeoutSeconds));
        webDriverWait.Until(ExpectedConditions.ElementToBeClickable(by));
    }

    public IComponent FindComponent(By locator)
    {
        var element = _webElement.FindElement(locator);
        return new ComponentAdapter(_webDriver, element, locator);
    }

    public IComponent FindInFrame(By locator)
    {
        _webDriver.SwitchTo().Frame(_webElement);
        var element = _webDriver.FindElement(locator);
        return new ComponentAdapter(_webDriver, element, locator);
    }

    public List<IComponent> FindComponents(By locator)
    {
        var elements = _webElement.FindElements(locator);
        var components = new List<IComponent>();
        foreach (var element in elements)
        {
            components.Add(new ComponentAdapter(_webDriver, element, locator));
        }
        return components;
    }

    public bool IsClickable()
    {
        try
        {
            var wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(3));
            wait.Until(ExpectedConditions.ElementToBeClickable(WrappedElement));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}