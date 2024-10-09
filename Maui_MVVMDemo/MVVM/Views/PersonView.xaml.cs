using Maui_MVVMDemo.MVVM.Models;
using Maui_MVVMDemo.MVVM.ViewModels;

namespace Maui_MVVMDemo.MVVM.Views;

public partial class PersonView : ContentPage
{
	public PersonView()
	{
		InitializeComponent();

		BindingContext = new PersonViewModel();
	}
}