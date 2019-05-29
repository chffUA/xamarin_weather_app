﻿using System;
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
        Repository repos = new Repository();

        private void SaveList()
        {
            repos.DeleteEntries();
            foreach(var entry in entries)
            {
                repos.InsertEntry(entry);
            }
        }

        private void LoadList()
        {
            try
            {
                var lst = repos.GetEntries();
                entries = new ObservableCollection<Entry>();
                foreach (var itm in lst)
                {
                    entries.Add(itm);
                }
            }
            catch(Exception ex)
            {
                var s = ex.Message;
            }
        }

        public MainPage()
        {
            try
            {
                repos.CreateDatabase();
            }
            catch(Exception ex)
            {
                var s = ex.Message;
                
            }
            InitializeComponent();
            LoadList();
            if (entries.Count==0)
            {
                try
                {
                    entries = new ObservableCollection<Entry>();
                    entries.Add(new Entry("Add +", "", 0));
                    var itm = new Entry("Porto", DateTime.Now.ToString(), 1);
                    entries.Add(itm);
                    itm = new Entry("Lisboa", DateTime.Now.ToString(), 1);
                    entries.Add(itm);
                }
                catch(Exception ex)
                {
                    var s = ex.Message;
                }
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
            Entry newEntry = new Entry(city, "Never", entries.Count);
            entries.Add(newEntry);
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
