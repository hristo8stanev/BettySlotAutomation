using NUnit.Framework;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IrishWildsPage AssertDefaultHamburgerMenuElementsAreDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(HamburgerMenuCloseButton().Displayed, Is.True, "Hamburger close button is not displayed");
            Assert.That(MuteSoundButton().Displayed, Is.True, "Mute sound button is not displayed");        
            Assert.That(TurboButton().Displayed, Is.True, "Turbo button is not displayed");
            Assert.That(InfoButton().Displayed, Is.True, "Info button is not displayed");
            Assert.That(SettingsButton().Displayed, Is.True, "Settings button is not displayed");
        });

        return this;
    }

    public IrishWildsPage AssertDesktopHamburgerMenuElementsAreDisplayed()
    {
        AssertDefaultHamburgerMenuElementsAreDisplayed();
        Assert.That(FullScreenButton().Displayed, Is.True, "Full screen button is not displayed");
        return this;
    }
}
