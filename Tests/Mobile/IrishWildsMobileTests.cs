using BettySlotAutomation.Constants;
using BettySlotAutomation.Enums;
using NUnit.Framework;

namespace BettySlotAutomation.Tests.Mobile;

[TestFixture(BrowserType.ChromeMobileIphone14ProMax)]
public class IrishWildsMobileTests : BaseTest
{
    public IrishWildsMobileTests(BrowserType browserType) : base(browserType) { }
    protected override void SelectGame() => SpinberryPage.SelectGameOnMobile(Games.IrishWilds);

    [SetUp]
    public void BeforeEach()
    {
        SelectGame();
        _driver.SwitchToLastWindow();
        _driver.WaitForPageLoad();
    }

    [Test]
    public void DefaultElementsAreDisplayed_When_GamePageIsLoaded()
    {
        IrishWildsPage.AssertAttractScreenElementsAreDisplayed();
    }

    [Test]
    public void GameElementsAreDisplayed_When_PlayButtonIsClicked()
    {
        IrishWildsPage.StartGame();

        IrishWildsPage.AssertGameElementsAreDisplayed();
    }

    [Test]
    public void HamburgerMenuElementsAreDisplayed_When_HamburgerMenuIsOpened()
    {
        IrishWildsPage.StartGame();

        IrishWildsPage.OpenHamburgerMenu();

        IrishWildsPage.AssertDefaultHamburgerMenuElementsAreDisplayed();
    }

    [Test]
    public void BuyFeaturePopupElementsAreDisplayed_When_BuyButtonIsClicked()
    {
        IrishWildsPage.StartGame();

        IrishWildsPage.OpenBuyFeaturePopup();

        IrishWildsPage.AssertBuyFeaturePopupElementsAreDisplayed();
    }

    [Test]
    public void InsufficientFundsLabelIsDisplayedAndBuyButtonIsDisabled_When_PriceExceedsBalance()
    {
        IrishWildsPage.StartGame();
        IrishWildsPage.OpenBuyFeaturePopup();

        IrishWildsPage.IncreasePriceUntilInsufficientFunds();

        IrishWildsPage.AssertInsufficientFundsIsDisplayed();
    }

    [Test]
    public void BalanceChanges_When_SingleSpinIsPerformed()
    {
        IrishWildsPage.StartGame();
        var initialBalance = IrishWildsPage.GetBalance();

        IrishWildsPage.PerformSpin(1);

        IrishWildsPage.AssertBalanceChangedAfterSpin(initialBalance);
    }

    [Test]
    public void BalanceChanges_When_MultipleSpinsArePerformed()
    {
        IrishWildsPage.StartGame();
        var initialBalance = IrishWildsPage.GetBalance();

        IrishWildsPage.PerformSpin(3);

        IrishWildsPage.AssertBalanceChangedAfterSpin(initialBalance);
    }

    [Test]
    public void AutoPlayElementsAreDisplayed_When_AutoPlayIsOpened()
    {
        IrishWildsPage.StartGame();

        IrishWildsPage.OpenAutoPlay();

        IrishWildsPage.AssertAutoPlayElementsAreDisplayed();
    }

    [Test]
    public void BalanceChangesAndSpinsCounterIsDisplayed_When_AutoPlayIsStarted()
    {
        IrishWildsPage.StartGame();
        var initialBalance = IrishWildsPage.GetBalance();

        IrishWildsPage.OpenAutoPlay();
        IrishWildsPage.StartAutoPlay();

        IrishWildsPage.AssertBalanceChangedAfterAutoPlay(initialBalance);
        IrishWildsPage.AssertAutoPlaySpinsCounterIsDisplayed();
        IrishWildsPage.AssertAutoPlayStopButtonIsDisplayed();
    }
}