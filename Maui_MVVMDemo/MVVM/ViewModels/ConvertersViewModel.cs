using Maui_MVVMDemo.MVVM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maui_MVVMDemo.MVVM.ViewModels
{
    public class ConvertersViewModel
    {
        public Data Data { get; set; }
        public ConvertersViewModel()
        {
            Data = new Data
            {
                Married = "YES"
            };
        }
    }
}
