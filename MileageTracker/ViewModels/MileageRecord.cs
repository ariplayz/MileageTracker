using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace MileageTracker.ViewModels;

public class MileageRecord
{
    public DateTime Date { get; set; }
    public decimal OdometerReading { get; set; }
    public decimal Mileage { get; set; }
    public string Description { get; set; } = string.Empty;
}