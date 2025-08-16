
using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace MileageTracker.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    private readonly ObservableCollection<TripRecord> _records;
    
    public ObservableCollection<TripRecord> Records => _records;

    [ObservableProperty]
    private DateTime _selectedDate = DateTime.Now;

    [ObservableProperty]
    private decimal _odometer;

    [ObservableProperty]
    private string _description = string.Empty;

    [ObservableProperty]
    private RecordType _recordType = RecordType.MileageOnly;

    [ObservableProperty]
    private decimal _gallons;

    [ObservableProperty]
    private decimal _pricePerGallon;

    [ObservableProperty]
    private TripRecord? _selectedRecord;

    [ObservableProperty]
    private bool _showFuelFields;

    public MainViewModel()
    {
        _records = new ObservableCollection<TripRecord>();
    }

    partial void OnRecordTypeChanged(RecordType value)
    {
        ShowFuelFields = value == RecordType.FuelUp;
    }

    private decimal CalculateMilesDriven()
    {
        var previousReading = _records.Any() ? _records.Max(x => x.OdometerReading) : 0;
        return Odometer - previousReading;
    }

    private decimal? CalculateMPG(decimal milesDriven, decimal gallons)
    {
        return gallons > 0 ? Math.Round(milesDriven / gallons, 1) : null;
    }

    [RelayCommand]
    private void Add()
    {
        if (Odometer <= 0) return;

        var milesDriven = CalculateMilesDriven();

        var record = new TripRecord
        {
            Date = SelectedDate,
            OdometerReading = Odometer,
            Description = Description,
            MilesDriven = milesDriven,
            IsFuelUp = RecordType == RecordType.FuelUp
        };

        if (RecordType == RecordType.FuelUp)
        {
            record.Gallons = Gallons;
            record.PricePerGallon = PricePerGallon;
            record.MPG = CalculateMPG(milesDriven, Gallons);
        }

        _records.Add(record);
        ResetFields();
    }

    private void ResetFields()
    {
        Description = string.Empty;
        Odometer = 0;
        SelectedDate = DateTime.Now;
        Gallons = 0;
        PricePerGallon = 0;
    }

    [RelayCommand]
    private void Delete()
    {
        if (SelectedRecord != null)
        {
            _records.Remove(SelectedRecord);
            SelectedRecord = null;
        }
    }
}