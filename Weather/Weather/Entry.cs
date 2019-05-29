using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    class Entry : IEquatable<Entry>
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int Index { get; set; }

        public Entry() { }

        public Entry(string n, string d, int i)
        {
            Name = n;
            Date = d;
            Index = i;
            Image = "http://pngimg.com/uploads/house/house_PNG50.png";
        }

        public Entry Copy()
        {
            var newItem = new Entry();
            newItem.ID = ID;
            newItem.Image = Image;
            newItem.Name = Name;
            newItem.Date = Date;
            newItem.Index = Index;
            return newItem;
        }

        public bool Equals(Entry other)
        {
            if (other == null)
                return false;
            if (ID == other.ID)
                return true;
            else
                return false;
        }
    }
}
