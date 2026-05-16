using BettySlotAutomation.Core.Interfaces;
using OpenQA.Selenium;

namespace BettySlotAutomation.Core.Utilities;

public class ComponentAdapter : IComponent
{
    public IWebElement WrappedElement { get; }
    public By Locator { get; }

    public string Text => throw new NotImplementedException();

    public bool? Enabled => throw new NotImplementedException();

    public bool? Displayed => throw new NotImplementedException();

    public ComponentAdapter(IWebElement element, By locator)
    {
        WrappedElement = element;
        Locator = locator;
    }

    public void TypeText(string text)
    {
        throw new NotImplementedException();
    }

    public void Click(bool waitToBeClickable = false)
    {
        throw new NotImplementedException();
    }

    public string GetAttribute(string attributeName)
    {
        throw new NotImplementedException();
    }

    public void Hover()
    {
        throw new NotImplementedException();
    }

    public IComponent FindComponent(By locator)
    {
        throw new NotImplementedException();
    }

    public List<IComponent> FindComponents(By locator)
    {
        throw new NotImplementedException();
    }
}
