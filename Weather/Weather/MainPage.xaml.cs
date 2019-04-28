using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Weather
{

    public partial class MainPage : ContentPage
    {

        ObservableCollection<Entry> entries = new ObservableCollection<Entry>();

        public MainPage()
        {       
            entries.Add(new Entry("Add +", "", 0));
            entries.Add(new Entry("Porto", DateTime.Now.ToString(), 1));
            entries.Add(new Entry("Lisboa", DateTime.Now.ToString(), 2));
            InitializeComponent();
            list.ItemsSource = entries;
        }

        public bool IsEntry(string city)
        {
            foreach (Entry e in entries)
                if (e.Name.Equals(city))
                    return true;

            return false;
        }

        public void AddModalSelection(string city)
        {
            entries.Add(new Entry(city, "Never", entries.Count));
        }

        public void RemoveEntry(object sender, EventArgs e) {

            //int idx = ((Entry)list.SelectedItem).Index;
            //var x = (ListView)((Button)sender).Parent;
            //entries.RemoveAt(idx);
        }

        public void OnItemSelected(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            Entry entry = (Entry)lv.SelectedItem;

            if (entry.Index==0)
            {
                Navigation.PushModalAsync(new SelectionModal(this));
            }
            else
            {
                Navigation.PushAsync(new NavigationPage(new StatsPage(entry)));
            }
            
        }
    }
}
