using BettySlotAutomation.Constants;
using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace BettySlotAutomation.Core;

public abstract partial class BasePage : IPage
{
    protected readonly IWebDriver Driver;
    protected readonly WebDriverWait Wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        Wait = new WebDriverWait(driver, TimeSpan.FromSeconds(BrowserConstants.DefaultTimeoutSeconds));
    }

    public virtual void WaitForPageToLoad()
    {
        Wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
    }
}
