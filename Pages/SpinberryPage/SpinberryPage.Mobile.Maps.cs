using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Pages.SpinberryPage;

public partial class SpinberryPage
{
    public IComponent CurrentGameTitle() => Driver.FindComponent(By.XPath("//div[contains(@class,'current')]//div[contains(@class,'video-slider-controls')]//h4"));

    public IComponent NextSlideButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'current')]//button[@aria-label='Next slide']"));

    public IComponent PrevSlideButton() => Driver.FindComponent(By.XPath("//div[contains(@class,'current')]//button[@aria-label='Previous slide']"));

    public IComponent PlayGameMobile() => Driver.FindComponent(By.XPath("//div[contains(@class,'current')]//a[contains(@class,'play')]"));
}