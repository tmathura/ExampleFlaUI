using System.Windows;

namespace ExampleFlaUI.WpfApp.Views
{
    /// <summary>
    /// Interaction logic for LoadingWindow.xaml
    /// </summary>
    public partial class LoadingWindow : Window
    {
        public LoadingWindow()
        {
            InitializeComponent();

            _ = CloseWindow();
        }

        private async Task CloseWindow()
        {
            await Task.Delay(TimeSpan.FromSeconds(2));

            Close();
        }
    }
}
