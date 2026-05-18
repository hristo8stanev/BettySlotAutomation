using NUnit.Framework;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IrishWildsPage AssertAutoPlayElementsAreDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(AutoPlayHeader().Displayed, Is.True, "AUTO header is not displayed");
            Assert.That(AutoPlayTab().Displayed, Is.True, "AutoPlay tab is not displayed");
            Assert.That(AutoPlayTotalSpinsTitle().Displayed, Is.True, "Total spins title is not displayed");
            Assert.That(AutoPlayTotalSpinsMinusButton().IsClickable, Is.True, "Total spins minus button is not displayed");
            Assert.That(AutoPlayTotalSpinsPlusButton().IsClickable, Is.True, "Total spins plus button is not displayed");
            Assert.That(AutoPlayStakeTitle().Displayed, Is.True, "Stake title is not displayed");
            Assert.That(AutoPlayTotalStakeTitle().Displayed, Is.True, "Total stake title is not displayed");
            Assert.That(AutoPlayLossLimitTitle().Displayed, Is.True, "Loss limit title is not displayed");
            Assert.That(AutoPlayStopOnWinAboveTitle().Displayed, Is.True, "Stop on win above title is not displayed");
            Assert.That(AutoPlayStopOnBonusFeatureTitle().Displayed, Is.True, "Stop on Bonus feature title is not displayed");
            Assert.That(AutoPlayStopOnBonusFeatureCheckbox().IsClickable, Is.True, "Stop on Bonus feature checkbox is not displayed");
            Assert.That(AutoPlayStartButton().IsClickable, Is.True, "Start button is not clickable");
            Assert.That(AutoPlayInfoButton().IsClickable, Is.True, "Info button is not clickable");
            Assert.That(AutoPlayCloseButton().IsClickable, Is.True, "Close button is not clickable");
        });

        return this;
    }

    public IrishWildsPage AssertBalanceChangedAfterAutoPlay(string initialBalance)
    {
        Assert.That(UserBalanceAmount().Text, Is.Not.EqualTo(initialBalance),
            $"Balance did not change after auto play started. Still showing: {initialBalance}");

        return this;
    }

    public IrishWildsPage AssertAutoPlaySpinsCounterIsDisplayed()
    {
        Assert.That(AutoPlaySpinsCounter().Displayed, Is.True, "Auto play spins counter is not displayed");

        return this;
    }

    public IrishWildsPage AssertAutoPlayStopButtonIsDisplayed()
    {
        Assert.That(AutoPlayStopButton().Displayed, Is.True, "Auto play stop button is not displayed");
        Assert.That(AutoPlayStopButton().IsClickable, Is.True, "Auto play stop button is not clickable");

        return this;
    }
}
