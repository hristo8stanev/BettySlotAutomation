using BettySlotAutomation.Core.Interfaces;
using BettySlotAutomation.Core.Utilities;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage
{
    public IComponent GameCard(string selectedGame) => Driver.FindComponent(By.XPath($"//h4[text()='{selectedGame}']/ancestor::div[contains(@class,'col')]"));
    public IComponent PlayGame(string selectedGame) => Driver.FindComponent(By.XPath($"//h4[text()='{selectedGame}']/ancestor::div[contains(@class,'col')]//a[contains(@class,'play')]"));
}
