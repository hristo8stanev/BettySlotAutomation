using BettySlotAutomation.Constants;
using BettySlotAutomation.Enums;
using NUnit.Framework;

namespace BettySlotAutomation.Tests.Mobile;

[TestFixture(BrowserType.ChromeMobileSamsungS20)]
[Category(TestCategories.Spinberry)]
[Category(TestCategories.Mobile)]
public class SpinberryMobileTests : BaseTest
{
    public SpinberryMobileTests(BrowserType browserType) : base(browserType) { }

    [Test]
    public void SpinberryPageSucceededLoaded_When_NavigatingToHomePage()
    {
        var expectedTitle = "Spinberry - Creators of new to market land-based & online gambling games";

        SpinberryPage.AssertPageTitleIsCorrect(expectedTitle);
    }

    [Test]
    public void SelectedGameSuccessfullyLoaded_When_SelectingGame()
    {
        var game = Games.Minimum10X;

        SpinberryPage.PlayGame(game).Hover();

        SpinberryPage.AssertPlayButtonIsVisibleOnHover(game);
    }
}
