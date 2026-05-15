using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using PercentageCalculator.Services;
using PercentageCalculator.Web;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");

builder.Services.AddSingleton<LocalStorageService>();
builder.Services.AddSingleton<ICalculationService, CalculationService>();
builder.Services.AddSingleton<IClipboardService, WebClipboardService>();

await builder.Build().RunAsync();
