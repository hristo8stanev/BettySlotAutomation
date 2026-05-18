using NUnit.Framework;

namespace BettySlotAutomation.Core.Utilities;

public static class Logger
{
    public static void Info(string message) =>
        TestContext.Progress.WriteLine($"[INFO  {Timestamp}] {message}");

    public static void Warning(string message) =>
        TestContext.Progress.WriteLine($"[WARN  {Timestamp}] {message}");

    public static void Error(string message) =>
        TestContext.Progress.WriteLine($"[ERROR {Timestamp}] {message}");

    private static string Timestamp => DateTime.Now.ToString("HH:mm:ss");
}
