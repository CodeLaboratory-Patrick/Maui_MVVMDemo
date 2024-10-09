using Maui_MVVMDemo.MVVM.ViewModels;

namespace Maui_MVVMDemo.MVVM.Views;

public partial class PeopleView : ContentPage
{
	public PeopleView()
	{
		InitializeComponent();

		BindingContext = new PeopleViewModel();
	}
}