using BettySlotAutomation.Enums;
using OpenQA.Selenium;

namespace BettySlotAutomation.Core.Interfaces
{
    public interface IDriver
    {
        public abstract string Url { get; }
        public string Title { get; }
        public void Start(BrowserType browser);
        public void Refresh();
        public void Quit();
        public void GoToUrl(string url);
        public IComponent FindComponent(By locator);
        public IComponent FindExisting(By locator);
        public IComponent FindInFrame(By locator);
        public List<IComponent> FindComponents(By locator);
        public IDriver SwitchToFrame(By locator);
        public IDriver SwitchToDefaultContent();
        public IDriver SwitchToLastWindow();
        public void WaitForPageLoad();
        public void DeleteAllCookies();
        public void AcceptCookies();
    }
}