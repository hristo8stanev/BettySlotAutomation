using BettySlotAutomation.Enums;
using Microsoft.Extensions.Configuration;

namespace BettySlotAutomation.Core.Configuration;

public static class TestConfiguration
{
    private static readonly IConfiguration _config;

    static TestConfiguration()
    {
        _config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddEnvironmentVariables()
            .Build();
    }

    public static string BaseUrl => _config["TestSettings:BaseUrl"]!;

    public static BrowserType? BrowserOverride
    {
        get
        {
            var browser = _config["TestSettings:Browser"];
            return string.IsNullOrEmpty(browser) ? null : Enum.Parse<BrowserType>(browser);
        }
    }
}
