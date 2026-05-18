using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.IrishWildsPage;

public partial class IrishWildsPage
{
    public IComponent AutoPlayHeader() => Driver.FindComponent(By.XPath("//ol[contains(@class,'tabs__list')]//li"));
    public IComponent AutoPlayTab() => Driver.FindComponent(By.XPath("//li[contains(@class,'tab__title') and text()='AUTOPLAY']"));
    public IComponent AutoPlayTotalSpinsTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Total spins']"));
    public IComponent AutoPlayTotalSpinsMinusButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'autoplay__wrapper')][.//p[text()='Total spins']]//button[.//*[@*='#MINUS']]"));
    public IComponent AutoPlayTotalSpinsPlusButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'autoplay__wrapper')][.//p[text()='Total spins']]//button[.//*[@*='#PLUS']]"));
    public IComponent AutoPlayStakeTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Stake']"));
    public IComponent AutoPlayTotalStakeTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Total stake']"));
    public IComponent AutoPlayLossLimitTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Loss limit']"));
    public IComponent AutoPlayStopOnWinAboveTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Stop on win above']"));
    public IComponent AutoPlayStopOnBonusFeatureTitle() => Driver.FindComponent(By.XPath("//p[@class='autoplay__title' and text()='Stop on Bonus feature']"));
    public IComponent AutoPlayStopOnBonusFeatureCheckbox() => Driver.FindComponent(By.XPath("//div[contains(@class,'checkbox _rounded-size')]//button"));
    public IComponent AutoPlayStartButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'autoplay')]//button[contains(@class,'button__primary')]"));
    public IComponent AutoPlayInfoButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'popup__button-wrapper')]//button[contains(@class,'_info')]"));
    public IComponent AutoPlayCloseButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'popup__button-wrapper')]//button[contains(@class,'cross')]"));
    public IComponent AutoPlaySpinsCounter() => Driver.FindComponent(By.XPath("//div[contains(@class,'display single__info-box')]//span"));
    public IComponent AutoPlayStopButton() => Driver.FindComponent(By.XPath("//button[@type='button']//span[contains(text(), 'STOP')]"));
}
