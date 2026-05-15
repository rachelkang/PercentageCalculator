# % Calculator

A sleek, cross-platform percentage calculator built with **.NET MAUI Blazor Hybrid** + **Blazor WebAssembly**. Shared Razor components power both a native desktop/mobile app and a web app from a single codebase.

**[🌐 Try it in your browser](https://rachelkang.github.io/PercentageCalculator/)** · **[📦 Download native apps](https://github.com/rachelkang/PercentageCalculator/releases)**

## Features

### 🔢 Percentage Calculator
Three calculation modes accessible via a tabbed selector:
- **% Change** — Enter two numbers to see what percentage higher or lower the second is compared to the first. Results show red for decreases.
- **% Of** — Calculate X% of a number.
- **Reverse Calc** — Find the original value before a percentage change was applied (e.g. "The price is $120 after a 20% increase — what was the original?").

Includes swap, copy to clipboard, and adjustable decimal precision (0–4 places).

### 💰 Tip Calculator
- Quick-pick tip buttons (10%, 15%, 18%, 20%, 25%) or custom input
- Bill splitting with a stepper control
- Shows tip amount and total

### 📜 History
- Timestamped log of all calculations across both pages
- Delete individual records or clear all
- Mode icons for quick scanning

### Accessibility
- Semantic HTML (`<form>`, `<main>`, `<nav>`, `<label for>`)
- ARIA attributes: `aria-live` on results, `role="alert"` on errors, `role="tablist"` on mode selector, `aria-pressed` on tip chips, `aria-label` on icon-only buttons
- Full keyboard navigation: Tab through fields, Enter to calculate
- Visible `:focus-visible` outlines

### Theming
- Dark/light mode via `prefers-color-scheme`
- Calculator-inspired aesthetic: monospace numbers, card-based layout, orange accent (dark) / purple accent (light)
- Custom app icon with a geometric **%** logo

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Framework | .NET MAUI Blazor Hybrid + Blazor WebAssembly (.NET 10) |
| Shared UI | Razor Class Library (components, styles, services) |
| Native shell | XAML (App, MainPage with BlazorWebView) |
| Web host | Blazor WebAssembly (standalone) |
| State | Razor component state (no MVVM framework needed) |
| DI | Built-in dependency injection |
| History | In-memory singleton service |

## Project Structure

```
PercentageCalculator/
├── PercentageCalculator.sln
│
├── PercentageCalculator.Shared/        # Shared Razor Class Library
│   ├── Components/
│   │   ├── Layout/
│   │   │   └── MainLayout.razor        # Bottom tab bar shell
│   │   ├── Pages/
│   │   │   ├── Calculator.razor        # 3-mode % calculator
│   │   │   ├── Tip.razor               # Tip calculator
│   │   │   └── History.razor           # Calculation history
│   │   └── Routes.razor                # Blazor router
│   ├── Models/
│   │   └── CalculationRecord.cs
│   ├── Services/
│   │   ├── ICalculationService.cs
│   │   ├── CalculationService.cs
│   │   └── IClipboardService.cs        # Platform-abstracted clipboard
│   └── wwwroot/css/app.css             # Calculator-themed dark/light styles
│
├── PercentageCalculator/               # .NET MAUI (desktop + mobile)
│   ├── App.xaml / App.xaml.cs          # Native MAUI app + window sizing
│   ├── MainPage.xaml                   # BlazorWebView host
│   ├── MauiProgram.cs                  # DI registration
│   ├── MauiClipboardService.cs         # Native clipboard implementation
│   └── Platforms/                      # Android, iOS, Mac, Windows
│
└── PercentageCalculator.Web/           # Blazor WebAssembly (browser)
    ├── App.razor                       # Web entry point → shared Routes
    ├── Program.cs                      # DI registration
    ├── WebClipboardService.cs          # Browser clipboard via JSInterop
    └── wwwroot/index.html
```

## Getting Started

### Prerequisites
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- For native apps, install the MAUI workload:
  ```
  dotnet workload install maui
  ```

### Run the Desktop App (Windows)
```bash
cd PercentageCalculator
dotnet build -f net10.0-windows10.0.19041.0 -t:Run
```

### Run the Web App
```bash
cd PercentageCalculator.Web
dotnet run
```
Then open http://localhost:5200 in your browser.

### Other Platforms
- **Android**: `dotnet build PercentageCalculator -f net10.0-android`
- **iOS**: `dotnet build PercentageCalculator -f net10.0-ios` (requires Mac + Xcode)
- **macOS**: `dotnet build PercentageCalculator -f net10.0-maccatalyst`
