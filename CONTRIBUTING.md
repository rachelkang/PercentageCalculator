# Contributing to % Calculator

Thanks for your interest in contributing! Here's how to get started.

## Development Setup

1. Install the [.NET 10 SDK](https://dotnet.microsoft.com/download)
2. Install the MAUI workload: `dotnet workload install maui`
3. Clone the repository
4. Open `PercentageCalculator.sln` in Visual Studio or your preferred IDE

## Project Structure

- **PercentageCalculator.Shared** — Shared Razor components, models, services, and CSS. Changes here affect both MAUI and web.
- **PercentageCalculator** — .NET MAUI project for desktop and mobile.
- **PercentageCalculator.Web** — Blazor WebAssembly project for the browser.

## Running Locally

```bash
# Desktop (Windows)
cd PercentageCalculator
dotnet build -f net10.0-windows10.0.19041.0 -t:Run

# Web
cd PercentageCalculator.Web
dotnet run
```

## Making Changes

1. Create a branch from `main`
2. Make your changes
3. Ensure all three projects build cleanly: `dotnet build` from the solution root
4. Test on at least one platform (desktop or web)
5. Open a pull request with a clear description of your changes

## Code Style

- Follow standard C# conventions
- Use meaningful names; avoid abbreviations
- Add `aria-label` to any new icon-only buttons
- Use `<label for="id">` for all form inputs
- Test with keyboard navigation (Tab/Enter) after UI changes

## Reporting Issues

Open a GitHub issue with:
- Steps to reproduce
- Expected vs actual behavior
- Platform (Windows/Android/iOS/Web/macOS)
