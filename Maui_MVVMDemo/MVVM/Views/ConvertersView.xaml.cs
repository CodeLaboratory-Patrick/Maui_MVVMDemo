using Maui_MVVMDemo.MVVM.ViewModels;

namespace Maui_MVVMDemo.MVVM.Views;

public partial class ConvertersView : ContentPage
{
	public ConvertersView()
	{
		InitializeComponent();

        BindingContext = new ConvertersViewModel();
    }
}