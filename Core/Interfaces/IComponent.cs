using OpenQA.Selenium;

namespace BettySlotAutomation.Core.Interfaces;

public interface IComponent
{
    public IWebElement WrappedElement { get; }
    public string Text { get; }
    public bool? Enabled { get; }
    public bool? Displayed { get; }
    public By Locator { get; }
    public void TypeText(string text);
    public void Click(bool waitToBeClickable = false);
    public bool IsClickable();
    public string GetAttribute(string attributeName);
    public void Hover();
    public IComponent FindComponent(By locator);
    public IComponent FindInFrame(By locator);
    public List<IComponent> FindComponents(By locator);
}
