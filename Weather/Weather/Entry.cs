using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    class Entry
    {
        public string Image { get; }
        public string Name { get; }
        public string Date { get; }
        public int Index { get;  }

        public Entry(string n, string d, int i)
        {
            Name = n;
            Date = d;
            Index = i;
            Image = "http://pngimg.com/uploads/house/house_PNG50.png";
        }
    }
}
