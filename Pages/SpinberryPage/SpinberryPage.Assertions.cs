using NUnit.Framework;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage
{
    public SpinberryPage AssertPageTitleIsCorrect(string expectedTitle)
    {
        Assert.That(Driver.Title, Does.Contain(expectedTitle), "Page title does not contain expected text");

        return this;
    }

    public SpinberryPage AssertPlayButtonIsVisibleOnHover(string selectedGame)
    {
        GameCard(selectedGame).Hover();

        Assert.That(PlayGame(selectedGame).Displayed, Is.True, $"Play button for '{selectedGame}' is not visible after hover");

        return this;
    }
}
