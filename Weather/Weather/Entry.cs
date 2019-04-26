using System;
using System.Collections.Generic;
using System.Text;

namespace Weather
{
    class Entry
    {
        public string Image { get; }
        public string Name { get; set; }
        public string Type { get; set; }

        public Entry(string n, string t)
        {
            Name = n;
            Type = t;
            Image = "http://pngimg.com/uploads/house/house_PNG50.png";
        }
    }
}
