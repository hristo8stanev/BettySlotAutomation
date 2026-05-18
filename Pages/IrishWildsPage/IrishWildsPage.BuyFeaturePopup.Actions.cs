namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public void OpenBuyFeaturePopup() => BuyButton().Click();

    public void IncreasePriceUntilInsufficientFunds(int maxClicks = 10)
    {
        for (int i = 0; i < maxClicks; i++)
        {
            if (InsufficientFunds().Displayed == true)
                break;

            BuyFeatureMinusButton().Click();
        }
    }
}
