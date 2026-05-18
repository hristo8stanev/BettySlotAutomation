using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    // Attract screen — top-level document
    public IComponent PlayButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__slider-play')]"));
    public IComponent NavigationLeftButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__slider-left')]"));
    public IComponent NavigationRightButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__slider-right')]"));

    // Game screen — top-level document after clicking PlayButton
    public IComponent UserBalanceAmount() => Driver.FindComponent(By.XPath("//span[text()='BALANCE']//following-sibling::span"));
    public IComponent UserWinBalance() => Driver.FindComponent(By.XPath("//span[text()='WIN']//following-sibling::span"));
    public IComponent BuyButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'_buy-feature-button')]"));
    public IComponent FeatureSpinButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'feature-spin-button')]"));
    public IComponent StakePlusButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__stake')][.//*[@*='#PLUS']]"));
    public IComponent StakeMinusButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button__stake')][.//*[@*='#MINUS']]"));
    public IComponent SpinButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'arrows-spin-button')]"));
    public IComponent AutoSpinButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'button')]//span[contains(text(),'AUTO')]"));
    public IComponent ClockIcon() => Driver.FindComponent(By.XPath("//div[contains(@class,'clock')]//p"));
}