using BettySlotAutomation.Core;
using BettySlotAutomation.Core.Interfaces;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage : BasePage
{
    public IrishWildsPage(IDriver driver) : base(driver)
    {
    }

    public override string Url => string.Empty;

    public void StartGame() => PlayButton().Click();

    public string GetBalance() => UserBalanceAmount().Text;

    public void PerformSpin(int times)
    {
        for (int i = 0; i < times; i++)
        {
            SpinButton().Click();
            WaitForSpinComplete();
        }
    }

    private void WaitForSpinComplete() => SpinButton();
}
