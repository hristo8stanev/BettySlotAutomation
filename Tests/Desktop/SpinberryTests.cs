using BettySlotAutomation.Constants;
using BettySlotAutomation.Enums;
using NUnit.Framework;

namespace BettySlotAutomation.Tests.Desktop;

[TestFixture(BrowserType.Chrome)]
[Category(TestCategories.Spinberry)]
public class SpinberryTests : BaseTest
{
    public SpinberryTests(BrowserType browserType) : base(browserType) { }

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
