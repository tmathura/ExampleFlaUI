using CommunityToolkit.Mvvm.Input;
using ExampleFlaUI.WpfApp.Models;
using ExampleFlaUI.WpfApp.Views;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace ExampleFlaUI.WpfApp.ViewModels;

public class MainViewModel : INotifyPropertyChanged
{
    public event PropertyChangedEventHandler PropertyChanged;

    private List<UserModel> _users;
    public List<UserModel> Users
    {
        get => _users;
        set
        {
            _users = value;
            PropertyChanged(this, new PropertyChangedEventArgs(nameof(Users)));
        }
    }

    public ICommand LoadDataCommand { get; }

    public MainViewModel()
    {
        LoadDataCommand = new RelayCommand(LoadData);
    }

    public void LoadData()
    {
        var loadingWindow = new LoadingWindow
        {
            Owner = Application.Current.MainWindow
        };

        loadingWindow.ShowDialog();

        Users =
        [
            new UserModel { Id = 1, Name = "John Doe" },
            new UserModel { Id = 2, Name = "Jane Doe" }
        ];
    }
}