using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage
{
    public IComponent AggreeCookiesButton => Driver.FindComponent(By.XPath("//div[@id=['cookie-consent']//following-sibling::button"));
}
