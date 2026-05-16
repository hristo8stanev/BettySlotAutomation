using BettySlotAutomation.Core.Interfaces;

namespace BettySlotAutomation.Core;

public abstract class BasePage
{
    protected readonly IDriver Driver;

    protected BasePage(IDriver driver)
    {
        Driver = driver;
    }

    public abstract string Url { get; }

    public void Navigate()
    {
        Driver.GoToUrl(Url);
    }
}