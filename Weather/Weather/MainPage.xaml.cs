using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weather
{

    [DesignTimeVisible(true)]
    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            List<Entry> entries = new List<Entry>();
            entries.Add(new Entry("n", "t"));
            entries.Add(new Entry("n2", "t2"));
            InitializeComponent();
            list.ItemsSource = entries;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;

            // assuiming Club has an Id property
            Application.Current.MainPage = new NavigationPage(new StatsPage(lv.SelectedItem));
        }
    }
}
