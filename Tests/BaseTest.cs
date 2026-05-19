using Allure.NUnit;
using BettySlotAutomation.Core.Configuration;
using BettySlotAutomation.Core.Interfaces;
using BettySlotAutomation.Core.Utilities;
using BettySlotAutomation.Enums;
using BettySlotAutomation.Pages.IrishWildsPage;
using BettySlotAutomation.Pages.SpinberryPage;
using NUnit.Framework;

namespace BettySlotAutomation.Tests;

[AllureNUnit]
public abstract class BaseTest
{
    private readonly BrowserType _browserType;
    protected IDriver _driver;
    protected SpinberryPage SpinberryPage;
    protected IrishWildsPage IrishWildsPage;

    protected BaseTest(BrowserType browserType)
    {
        _browserType = browserType;
    }

    protected virtual void SelectGame(){}

    [SetUp]
    public void TestInit()
    {
        var browser = TestConfiguration.BrowserOverride ?? _browserType;

        Logger.Info($"TEST STARTED: {TestContext.CurrentContext.Test.Name} [{browser}]");

        _driver = new DriverAdapter();
        _driver.Start(browser);
        SpinberryPage = new SpinberryPage(_driver);
        IrishWildsPage = new IrishWildsPage(_driver);
        SpinberryPage.Navigate();
        _driver.AcceptCookies();
    }

    [TearDown]
    public void TestCleanup()
    {
        var result = TestContext.CurrentContext.Result.Outcome.Status;
        var testName = TestContext.CurrentContext.Test.Name;

        if (result == NUnit.Framework.Interfaces.TestStatus.Passed)
            Logger.Info($"TEST PASSED: {testName}");
        else
            Logger.Error($"TEST FAILED: {testName} — {TestContext.CurrentContext.Result.Message}");

        _driver.Quit();
    }
}
