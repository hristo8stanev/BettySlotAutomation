using BettySlotAutomation.Core;
using BettySlotAutomation.Core.Interfaces;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage : BasePage
{
    public SpinberryPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => Urls.SpinberryUrls.BaseUrl;

    public void SelectGame(string game)
    {
        PlayGame(game).Hover();
        PlayGame(game).Click(true);
    }

    public void SelectGameOnMobile(string game)
    {
        PrevSlideButton().Hover();
        while (CurrentGameTitle().Text != game)
            PrevSlideButton().Click();

        PlayGameMobile().Click();
    }
}
