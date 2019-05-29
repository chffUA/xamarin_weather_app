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

        public void SaveList()
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
                AddEntry("Porto");
                AddEntry("Lisboa");
            }
            //SaveList();
            list.ItemsSource = entries;
        }

        public bool IsEntry(string city)
        {
            foreach (Entry e in entries)
                if (e.Name.Equals(city))
                    return true;

            return false;
        }

        public void TouchEntry(Entry e)
        {
            int idx = entries.IndexOf(e);
            entries.Insert(idx, new Entry(e.Name, DateTime.Now, idx));
            entries.Remove(e);
            SaveList();
        }

        public void AddEntry(string city)
        {
            entries.Add(new Entry(city, entries.Count));
            SaveList();
        }

        public void VisitSelectionModal(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new SelectionModal(this));
        }

        public void RemoveEntry(object sender, EventArgs e)
        {
            var city = (Entry)((Button)sender).BindingContext;
            entries.Remove(city);
            SaveList();
        }

        public void OnItemSelected(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            Entry entry = (Entry)lv.SelectedItem;
            Navigation.PushModalAsync(new NavigationPage(new StatsPage(entry, this)));
        }

    }
}
