using Avalonia.Controls;
using Avalonia.Interactivity;

namespace WinHelper.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AboutComputerButton_OnClick(object? sender, RoutedEventArgs e)
        {
            Presenter.Content = new AboutComputerView();
        }
    }
}