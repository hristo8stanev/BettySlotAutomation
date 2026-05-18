using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IComponent HamburgerMenuButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'hamburger') and contains(@class,'game__menu') and not(contains(@class,'_close'))]"));
    public IComponent HamburgerMenuCloseButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'hamburger') and contains(@class,'_close')]"));
    public IComponent MuteSoundButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'_opened')]//button[.//*[contains(@*, 'SOUND')]]"));
    public IComponent FullScreenButton() => Driver.FindComponent(By.XPath("//button[.//*[@*='#FULL_SCREEN_ICON']]"));
    public IComponent TurboButton() => Driver.FindComponent(By.XPath("//button[.//*[@*='#TURBO_ICON']]"));
    public IComponent InfoButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'_info')][.//*[@*='#INFO']]"));
    public IComponent SettingsButton() => Driver.FindComponent(By.XPath("//button[contains(@class,'game__settings')]"));
}