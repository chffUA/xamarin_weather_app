using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class StatsPage : ContentPage
    {
        public string Name { get; set; }
        public StatsPage(object n)
        {
            InitializeComponent();
            Console.WriteLine(((Entry)n).Name);
            Name = ((Entry)n).Name;
            la.Text = Name;
            
            
        }
    }
}