namespace PercentageCalculator.Models;

public enum CalculationMode
{
    PercentChange,
    PercentOf,
    ReverseCalc,
    TipCalc
}

public class CalculationRecord
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public CalculationMode Mode { get; set; }
    public string InputSummary { get; set; } = string.Empty;
    public string Result { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; } = DateTime.Now;

    public string ModeIcon => Mode switch
    {
        CalculationMode.PercentChange => "📊",
        CalculationMode.PercentOf => "🔢",
        CalculationMode.ReverseCalc => "🔄",
        CalculationMode.TipCalc => "💰",
        _ => "📐"
    };

    public string TimeAgo
    {
        get
        {
            var span = DateTime.Now - Timestamp;
            if (span.TotalMinutes < 1) return "Just now";
            if (span.TotalMinutes < 60) return $"{(int)span.TotalMinutes}m ago";
            if (span.TotalHours < 24) return $"{(int)span.TotalHours}h ago";
            return Timestamp.ToString("MMM d, h:mm tt");
        }
    }
}
