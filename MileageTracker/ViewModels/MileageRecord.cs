namespace MileageTracker.ViewModels;
using System;

public class MileageRecord
{
    public DateTime Date { get; set; }
    public decimal Mileage { get; set; }
    public string Description { get; set; } = string.Empty;
    public decimal OdometerReading { get; set; }
}