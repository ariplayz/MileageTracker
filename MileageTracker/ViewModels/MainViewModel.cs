using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MileageTracker.ViewModels;
using MileageTracker;
using System.Collections.ObjectModel;
using System;

namespace MileageTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    private ObservableCollection<MileageRecord> _mileageRecords = new();

    [ObservableProperty]
    private DateTime _currentDate = DateTime.Now;

    [ObservableProperty]
    private decimal _odometerReading;

    [ObservableProperty]
    private string _description = string.Empty;

    [RelayCommand]
    private void AddRecord()
    {
        var record = new MileageRecord
        {
            Date = CurrentDate,
            OdometerReading = OdometerReading,
            Description = Description,
            Mileage = OdometerReading // You might want to calculate the difference from the previous reading
        };

        MileageRecords.Add(record);
        
        // Clear the input fields
        Description = string.Empty;
        OdometerReading = 0;
    }
}