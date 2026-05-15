using Microsoft.JSInterop;

namespace PercentageCalculator.Services;

/// <summary>
/// localStorage wrapper using JSInterop. Works in both Blazor WASM
/// and MAUI's BlazorWebView (which also has localStorage).
/// </summary>
public class LocalStorageService
{
    private readonly IJSRuntime _js;

    public LocalStorageService(IJSRuntime js)
    {
        _js = js;
    }

    public async Task<string?> GetAsync(string key)
    {
        try
        {
            return await _js.InvokeAsync<string?>("localStorage.getItem", key);
        }
        catch
        {
            return null;
        }
    }

    public async Task SetAsync(string key, string value)
    {
        try
        {
            await _js.InvokeVoidAsync("localStorage.setItem", key, value);
        }
        catch
        {
            // Storage may be unavailable (e.g. private browsing)
        }
    }

    public async Task RemoveAsync(string key)
    {
        try
        {
            await _js.InvokeVoidAsync("localStorage.removeItem", key);
        }
        catch
        {
            // Ignore
        }
    }
}
