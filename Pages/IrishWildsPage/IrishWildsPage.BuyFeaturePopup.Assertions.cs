using NUnit.Framework;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IrishWildsPage AssertInsufficientFundsIsDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(InsufficientFunds().Displayed, Is.True, "Insufficient funds label is not displayed");
            Assert.That(BuyFeaturePopupBuyButton().GetAttribute("class"), Does.Contain("disabled"), "Buy button should be disabled when funds are insufficient");
        });

        return this;
    }

    public IrishWildsPage AssertBuyFeaturePopupElementsAreDisplayed()
    {
        Assert.Multiple(() =>
        {
            Assert.That(BuyFeatureHeader().Text, Does.Contain("BUY FEATURE"), "Buy feature header text is incorrect");
            Assert.That(PriceParagraph().Text, Does.Contain("PRICE"), "Price paragraph text is incorrect");
            Assert.That(WithBetParagraph().Text, Does.Contain("WITH BET"), "With bet paragraph text is incorrect");
            Assert.That(BuyFeatureStakeBetAmount().Displayed, Is.True, "Stake bet amount is not displayed");
            Assert.That(BuyFeatureMinusButton().Displayed, Is.True, "Minus button is not displayed");
            Assert.That(BuyFeaturePlusButton().Displayed, Is.True, "Plus button is not displayed");
            Assert.That(BuyFeaturePopupBuyButton().Displayed, Is.True, "Buy button is not displayed");
            Assert.That(BuyFeatureCloseButton().Displayed, Is.True, "Close button is not displayed");
        });

        return this;
    }
}
