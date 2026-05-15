namespace PercentageCalculator.Services;

public interface IClipboardService
{
    Task SetTextAsync(string text);
}
