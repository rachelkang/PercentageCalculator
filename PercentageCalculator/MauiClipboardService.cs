using PercentageCalculator.Services;

namespace PercentageCalculator;

public class MauiClipboardService : IClipboardService
{
    public Task SetTextAsync(string text)
        => Clipboard.Default.SetTextAsync(text);
}
