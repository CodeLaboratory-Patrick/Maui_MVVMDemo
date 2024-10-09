using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maui_MVVMDemo.MVVM.ViewModels
{
    public class CommandsViewModel
    {
        public ICommand ClickCommand { get; }
        public ICommand SearchCommand { get; }
        public string SearchTerm { get; set; }

        public CommandsViewModel()
        {
            ClickCommand = new Command(() =>
            {
                App.Current.MainPage
                .DisplayAlert("Title", "message", "Ok");
            });
            SearchCommand = new Command((s) =>
            {
                var data = s;
            });
        }

        private void Alert()
        {

        }

        //The first option.
        //public ICommand ClickCommand => new Command(() => App.Current.MainPage.DisplayAlert("Title", "message", "Ok"));


        // The second option.
        //public ICommand ClickCommand => new Command(Alert);

        //private void Alert()
        //{
        //    App.Current.MainPage.DisplayAlert("Title", "message", "Ok");
        //}
    }
}
