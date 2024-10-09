using Maui_MVVMDemo.MVVM.Views;

namespace Maui_MVVMDemo
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ConvertersView();
        }
    }
}
