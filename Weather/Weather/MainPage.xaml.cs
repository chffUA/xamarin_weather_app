using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weather
{

    public partial class MainPage : ContentPage
    {

        public MainPage()
        {
            List<Entry> entries = new List<Entry>();
            entries.Add(new Entry("Add +", "", 0));
            entries.Add(new Entry("Porto", DateTime.Now.ToString(), 1));
            entries.Add(new Entry("Lisboa", DateTime.Now.ToString(), 2));
            InitializeComponent();
            list.ItemsSource = entries;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView lv = (ListView)sender;
            Entry entry = (Entry)lv.SelectedItem;

            if (entry.Index==0)
            {
                Navigation.PushModalAsync(new SelectionModal());
            }
            else
            {
                Application.Current.MainPage = new NavigationPage(new StatsPage(entry));
            }
            
        }
    }
}
