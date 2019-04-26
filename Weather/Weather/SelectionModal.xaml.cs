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
    public partial class SelectionModal : ContentPage
    {
        private readonly string[] choices = { "Porto", "Lisboa", "Coimbra" };

        public SelectionModal()
        {
            InitializeComponent();

            foreach (string c in choices)
                picker.Items.Add(c);
        }
    }
}