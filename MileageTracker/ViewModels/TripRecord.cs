using System;

namespace MileageTracker.ViewModels;

public class TripRecord
{
    public DateTime Date { get; set; }
    public decimal OdometerReading { get; set; }
    public decimal MilesDriven { get; set; }
    public string Description { get; set; } = string.Empty;
    public bool IsFuelUp { get; set; }
    public decimal? Gallons { get; set; }
    public decimal? PricePerGallon { get; set; }
    public decimal? TotalCost => Gallons * PricePerGallon;
    public decimal? MPG { get; set; }
}