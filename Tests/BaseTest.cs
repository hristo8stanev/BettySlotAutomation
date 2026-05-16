using BettySlotAutomation.Core.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace BettySlotAutomation.Tests;

[TestFixture]
public abstract class BaseTest
{
    protected IWebDriver Driver { get; private set; } = null!;
    public SpinberryTests SpinberryTests;

    [SetUp]
    public void SetUp()
    {
        Driver = DriverFactory.CreateDriver();
        SpinberryTests = new SpinberryTests(Driver);
    }

    [TearDown]
    public void TearDown()
    {
        Driver?.Quit();
        Driver?.Dispose();
    }
}
