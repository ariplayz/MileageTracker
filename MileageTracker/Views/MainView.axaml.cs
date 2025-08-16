using Avalonia.Controls;

namespace MileageTracker.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
        DataContext = new ViewModels.MainViewModel();
    }
}