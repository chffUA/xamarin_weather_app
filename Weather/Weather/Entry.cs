using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    public class Entry
    {
        public string Image { get; }
        public string Name { get; }
        public DateTime Date { get; set; }
        public int Index { get;  }

        public string LastChecked
        { get
            {
                if (Date == DateTime.MinValue) return "Last Checked: Never";
                else return "Last Checked: " + Date.ToString();
            }
        }

        public Entry(string n, DateTime d, int i) //forced date
        {
            Name = n;
            Date = d;
            Index = i;
            Image = "http://pngimg.com/uploads/house/house_PNG50.png";
        }

        public Entry(string n, int i) //current date
        {
            Name = n;
            Date = DateTime.MinValue;
            Index = i;
            Image = "http://pngimg.com/uploads/house/house_PNG50.png";
        }

    }
}
