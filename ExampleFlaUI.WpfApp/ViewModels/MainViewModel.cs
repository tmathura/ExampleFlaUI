using System.Windows.Input;
using System.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ExampleFlaUI.WpfApp.Models;

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
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Users)));
        }
    }

    public ICommand LoadDataCommand { get; }

    public MainViewModel()
    {
        LoadDataCommand = new RelayCommand(LoadData);
    }

    public void LoadData()
    {
        Users =
        [
            new UserModel { Id = 1, Name = "John Doe" },
            new UserModel { Id = 2, Name = "Jane Doe" }
        ];
    }
}