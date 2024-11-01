using Reqnroll;
using Reqnroll.Tracing;
using Reqnroll.Tracing.AnsiColor;
using ReqnrollSampleProject.Settings;
using Microsoft.Extensions.Options;

namespace ReqnrollSampleProject.Steps;

[Binding]
public class Hooks(IOptions<AppSettings> appSettings)
{
    [BeforeTestRun]
    public static void BeforeTestRun(IColorOutputTheme colorOutputTheme)
    {
        colorOutputTheme.Keyword = AnsiColor.Reset;
        colorOutputTheme.Error = AnsiColor.Composite(AnsiColor.Bold, AnsiColor.Foreground(TerminalRgbColor.FromHex("FF0000")));
        colorOutputTheme.Done = AnsiColor.Foreground(TerminalRgbColor.FromHex("00FF00"));
        colorOutputTheme.Warning = AnsiColor.Foreground(TerminalRgbColor.FromHex("FFD700"));
    }

    [BeforeScenario]
    public void BeforeScenario()
    {
        Console.WriteLine($"Base url: {appSettings.Value.BaseUrl}");
    }
}