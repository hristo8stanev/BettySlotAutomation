using BettySlotAutomation.Enums;
using OpenQA.Selenium;

namespace BettySlotAutomation.Core.Interfaces
{
    public interface IDriver
    {
        public abstract string Url { get; }
        public void Start(BrowserType browser);
        public void Refresh();
        public void Quit();
        public void GoToUrl(string url);
        public IComponent FindComponent(By locator);
        public List<IComponent> FindComponents(By locator);
    }
}