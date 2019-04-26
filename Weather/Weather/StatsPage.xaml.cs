using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Weather
{
    [XamlCompilation(XamlCompilationOptions.Compile)]

    public partial class StatsPage : ContentPage
    {
        private string apikey = "bf44898d91e348588e1192019192604";
        private Entry entry;
        private string json;

        public StatsPage(object e)
        {
            InitializeComponent();
            entry = (Entry)e;
            la.Text = "Loading...";
            FetchFromAPI(entry.Name);
        }

        public async void FetchFromAPI(string city)
        {
            string link = "http://api.apixu.com/v1/current.json?key="+apikey+"&q="+city+",Portugal";
            la.Text = await GetAsync(link);
        }

        public async Task<string> GetAsync(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;

            using (HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                return await reader.ReadToEndAsync();
            }
        }
    }
}