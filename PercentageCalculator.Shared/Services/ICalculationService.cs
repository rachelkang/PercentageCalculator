using PercentageCalculator.Models;

namespace PercentageCalculator.Services;

public interface ICalculationService
{
    /// <summary>Calculate what % B is higher/lower than A.</summary>
    (double percentage, bool isHigher) PercentChange(double a, double b);

    /// <summary>Calculate X% of Y.</summary>
    double PercentOf(double percentage, double number);

    /// <summary>Find the original value before a % change produced the given result.</summary>
    double ReverseCalc(double result, double percentChange);

    /// <summary>Calculate tip details.</summary>
    (double tipAmount, double total, double perPerson) CalculateTip(double billAmount, double tipPercent, int splitCount);

    /// <summary>History of calculations.</summary>
    IReadOnlyList<CalculationRecord> History { get; }

    void AddToHistory(CalculationRecord record);
    void RemoveFromHistory(string id);
    void ClearHistory();

    /// <summary>Load history from persistent storage. Call once on app startup.</summary>
    Task LoadHistoryAsync();
}
