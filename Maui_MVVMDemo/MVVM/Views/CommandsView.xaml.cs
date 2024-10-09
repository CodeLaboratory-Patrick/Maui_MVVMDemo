using Maui_MVVMDemo.MVVM.ViewModels;

namespace Maui_MVVMDemo.MVVM.Views;

public partial class CommandsView : ContentPage
{
    public CommandsView()
    {
        InitializeComponent();
        BindingContext = new CommandsViewModel();
    }
}