using NUnit.Framework;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IrishWildsPage AssertAttractScreenElementsAreDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(PlayButton().Displayed, Is.True, "Play button is not displayed");
            Assert.That(NavigationLeftButton().Displayed, Is.True, "Navigation left button is not displayed");
            Assert.That(NavigationRightButton().Displayed, Is.True, "Navigation right button is not displayed");
        });

        return this;
    }

    public IrishWildsPage AssertBalanceChangedAfterSpin(string initialBalance)
    {
        Assert.That(UserBalanceAmount().Text, Is.Not.EqualTo(initialBalance),
            $"Balance did not change after spin. Still showing: {initialBalance}");

        return this;
    }

    public IrishWildsPage AssertGameElementsAreDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(UserBalanceAmount().Displayed, Is.True, "User balance amount is not displayed");
            Assert.That(UserWinBalance().Displayed, Is.True, "User win balance is not displayed");
            Assert.That(BuyButton().Displayed, Is.True, "Buy button is not displayed");
            Assert.That(FeatureSpinButton().Displayed, Is.True, "Feature spin button is not displayed");
            Assert.That(StakePlusButton().Displayed, Is.True, "Stake plus button is not displayed");
            Assert.That(StakeMinusButton().Displayed, Is.True, "Stake minus button is not displayed");
            Assert.That(SpinButton().Displayed, Is.True, "Spin button is not displayed");
            Assert.That(AutoSpinButton().Displayed, Is.True, "Auto spin button is not displayed");
            Assert.That(ClockIcon().Displayed, Is.True, "Clock icon is not displayed");
        });

        return this;
    }
}
