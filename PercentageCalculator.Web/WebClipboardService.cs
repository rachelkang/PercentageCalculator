using Microsoft.JSInterop;
using PercentageCalculator.Services;

namespace PercentageCalculator.Web;

public class WebClipboardService : IClipboardService
{
    private readonly IJSRuntime _js;

    public WebClipboardService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task SetTextAsync(string text)
    {
        await _js.InvokeVoidAsync("navigator.clipboard.writeText", text);
    }
}
