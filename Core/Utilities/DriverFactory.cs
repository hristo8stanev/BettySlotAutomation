using BettySlotAutomation.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace BettySlotAutomation.Core.Utilities;

public static class DriverFactory
{
    public static IWebDriver CreateDriver(BrowserType browserType = BrowserType.Chrome)
    {
        switch (browserType)
        {
            case BrowserType.Chrome:
                return CreateChrome(headless: false);
            case BrowserType.ChromeHeadless:
                return CreateChrome(headless: true);
            case BrowserType.Firefox:
                return CreateFirefox(headless: false);
            case BrowserType.FirefoxHeadless:
                return CreateFirefox(headless: true);
            case BrowserType.Edge:
                return CreateEdge(headless: false);
            case BrowserType.EdgeHeadless:
                return CreateEdge(headless: true);
            default:
                throw new NotSupportedException($"Browser '{browserType}' is not supported.");
        }
    }

    private static IWebDriver CreateChrome(bool headless)
    {
        new DriverManager().SetUpDriver(new ChromeConfig());
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }
        return new ChromeDriver(options);
    }

    private static IWebDriver CreateFirefox(bool headless)
    {
        new DriverManager().SetUpDriver(new FirefoxConfig());
        var options = new FirefoxOptions();
        if (headless)
        {
            options.AddArgument("--headless");
            options.AddArgument("--width=1920");
            options.AddArgument("--height=1080");
        }
        return new FirefoxDriver(options);
    }

    private static IWebDriver CreateEdge(bool headless)
    {
        new DriverManager().SetUpDriver(new EdgeConfig());
        var options = new EdgeOptions();
        options.AddArgument("--start-maximized");
        if (headless)
        {
            options.AddArgument("--headless=new");
            options.AddArgument("--window-size=1920,1080");
        }
        return new EdgeDriver(options);
    }
}
