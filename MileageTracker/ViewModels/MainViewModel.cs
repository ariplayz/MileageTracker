using Avalonia.Collections;
using System;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MileageTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    public AvaloniaList<MileageRecord> Records { get; } = new();
    
    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Now;
    
    [ObservableProperty]
    private decimal _odometer;
    
    [ObservableProperty]
    private string _description = string.Empty;
    
    [ObservableProperty]
    private MileageRecord? _selectedRecord;

    [RelayCommand]
    private void Add()
    {
        if (Odometer <= 0) return;

        var lastReading = Records.Any() ? Records.Max(x => x.OdometerReading) : 0;
        var milesDriven = Odometer - lastReading;

        var record = new MileageRecord
        {
            Date = SelectedDate,
            OdometerReading = Odometer,
            Description = Description,
            Mileage = milesDriven
        };

        Records.Add(record);

        // Reset fields
        Description = string.Empty;
        Odometer = 0;
        SelectedDate = DateTime.Now;
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedRecord != null)
        {
            Records.Remove(SelectedRecord);
            SelectedRecord = null;
        }
    }
}