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
        ObservableCollection<Entry> entries;

        private void SaveList()
        {
            Application.Current.Properties["list"] = entries;
            Application.Current.SavePropertiesAsync();
        }

        private void LoadList()
        {
            if (Application.Current.Properties.ContainsKey("list"))
            {
                var lst = Application.Current.Properties["list"];
                entries = (ObservableCollection<Entry>)lst;
            }
        }

        public MainPage()
        {
            InitializeComponent();
            LoadList();
            if (entries == null)
            {
                entries = new ObservableCollection<Entry>();
                entries.Add(new Entry("Add +", "", 0));
                entries.Add(new Entry("Porto", DateTime.Now.ToString(), 1));
                entries.Add(new Entry("Lisboa", DateTime.Now.ToString(), 1));
            }
            SaveList();
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
            SaveList();
        }

        public void RemoveEntry(object sender, EventArgs e)
        {
            var city = (Entry)((Xamarin.Forms.Button)sender).BindingContext;
            entries.Remove(city);
            SaveList();
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
