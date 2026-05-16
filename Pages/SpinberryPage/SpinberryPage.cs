using BettySlotAutomation.Core;
using BettySlotAutomation.Core.Interfaces;
using Newtonsoft.Json.Bson;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage : BasePage
{
    public SpinberryPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.SpinberryUrls.BaseUrl;

    public void AcceptCookies()
    {
        AggreeCookiesButton.Click();
    }
}
