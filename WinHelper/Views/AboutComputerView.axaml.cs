using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WinHelper.ViewModels;

namespace WinHelper.Views;

public partial class AboutComputerView : UserControl
{
    public AboutComputerView()
    {
        InitializeComponent();
        DataContext = new AboutComputerViewModel();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}