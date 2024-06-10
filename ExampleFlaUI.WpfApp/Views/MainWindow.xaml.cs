using ExampleFlaUI.WpfApp.ViewModels;

namespace ExampleFlaUI.WpfApp.Views;

public partial class MainWindow
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}