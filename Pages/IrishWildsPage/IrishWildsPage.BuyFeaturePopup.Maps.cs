using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IComponent BuyFeatureHeader() => Driver.FindComponent(By.XPath("//div[contains(@class,'_buy-feature')]//h2"));
    public IComponent PriceParagraph() => Driver.FindComponent(By.XPath("//div[contains(@class,'content__item')]//p[text()='PRICE']"));
    public IComponent WithBetParagraph() => Driver.FindComponent(By.XPath("//div[contains(@class,'content__item _with-button')]//p"));
    public IComponent BuyFeaturePopupBuyButton() => Driver.FindExisting(By.XPath("//div[contains(@class,'item__with-subtext')]//button"));
    public IComponent BuyFeatureMinusButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'_buy-feature')]//button[contains(@class,'button__stake')][.//*[@*='#MINUS']]"));
    public IComponent BuyFeaturePlusButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'_buy-feature')]//button[contains(@class,'button__stake')][.//*[@*='#PLUS']]"));
    public IComponent BuyFeatureStakeBetAmount() => Driver.FindComponent(By.XPath("//div[contains(@class,'_buy-feature')]//div[contains(@class,'display__wrapper')]"));
    public IComponent BuyFeatureCloseButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__cross')]"));
    public IComponent InsufficientFunds() => Driver.FindExisting(By.XPath("//div[contains(@class,'with-subtext')]/span"));
}
