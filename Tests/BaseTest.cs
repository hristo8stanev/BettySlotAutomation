using BettySlotAutomation.Core.Interfaces;
using BettySlotAutomation.Core.Utilities;
using BettySlotAutomation.Enums;
using BettySlotAutomation.Pages.SpinberryPage;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BettySlotAutomation.Tests;

[TestFixture]
public abstract class BaseTest
{
    protected IDriver _driver;
    protected SpinberryPage SpinberryPage;

    [SetUp]
    public void TestInit()
    {
        _driver = new DriverAdapter();
        _driver.Start(BrowserType.CHROME);
        SpinberryPage = new SpinberryPage(_driver);
    }

    [TearDown]
    public void TestCleanup()
    {
        _driver.Quit();
    }
}
