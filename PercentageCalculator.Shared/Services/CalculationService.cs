using System.Text.Json;
using PercentageCalculator.Models;

namespace PercentageCalculator.Services;

public class CalculationService : ICalculationService
{
    private const string StorageKey = "calc_history";
    private readonly LocalStorageService _storage;
    private List<CalculationRecord> _history = [];
    private bool _loaded;

    public CalculationService(LocalStorageService storage)
    {
        _storage = storage;
    }

    public IReadOnlyList<CalculationRecord> History => _history.AsReadOnly();

    public async Task LoadHistoryAsync()
    {
        if (_loaded) return;
        var json = await _storage.GetAsync(StorageKey);
        if (!string.IsNullOrEmpty(json))
        {
            _history = JsonSerializer.Deserialize<List<CalculationRecord>>(json) ?? [];
        }
        _loaded = true;
    }

    private async void PersistAsync()
    {
        try
        {
            var json = JsonSerializer.Serialize(_history);
            await _storage.SetAsync(StorageKey, json);
        }
        catch
        {
            // Best-effort persistence
        }
    }

    public (double percentage, bool isHigher) PercentChange(double a, double b)
    {
        if (a == 0)
            throw new ArgumentException("Base value (A) cannot be zero.");

        double change = ((b - a) / Math.Abs(a)) * 100;
        return (Math.Abs(change), change >= 0);
    }

    public double PercentOf(double percentage, double number)
    {
        return (percentage / 100.0) * number;
    }

    public double ReverseCalc(double result, double percentChange)
    {
        double factor = 1 + (percentChange / 100.0);
        if (factor == 0)
            throw new ArgumentException("A -100% change cannot be reversed (original would be infinite).");

        return result / factor;
    }

    public (double tipAmount, double total, double perPerson) CalculateTip(double billAmount, double tipPercent, int splitCount)
    {
        if (splitCount < 1)
            throw new ArgumentException("Split count must be at least 1.");

        double tipAmount = billAmount * (tipPercent / 100.0);
        double total = billAmount + tipAmount;
        double perPerson = total / splitCount;
        return (tipAmount, total, perPerson);
    }

    public void AddToHistory(CalculationRecord record)
    {
        _history.Insert(0, record);
        if (_history.Count > 100)
            _history.RemoveAt(_history.Count - 1);
        PersistAsync();
    }

    public void RemoveFromHistory(string id)
    {
        var item = _history.FirstOrDefault(r => r.Id == id);
        if (item != null) _history.Remove(item);
        PersistAsync();
    }

    public void ClearHistory()
    {
        _history.Clear();
        PersistAsync();
    }
}
