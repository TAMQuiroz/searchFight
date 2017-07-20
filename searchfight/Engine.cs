using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace searchfight
{
    class Engine
    {
        public string Name { get; set; }

        public string ConnectionString { get; set; }

        public int TotalResults { get; set; }

        public Webpages WebPages { get; set; }

        public Searchinformation SearchInformation { get; set; }

        public int Request(string arg)
        {
            string html = string.Empty;

            string url = this.ConnectionString + arg;

            //Request
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            if (this.Name == "Bing") request.Headers.Add("Ocp-Apim-Subscription-Key", "793a9b2348994fcfb54a55f2eb09a2ee");

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            //Parsing
            if (this.Name == "Bing") this.TotalResults = JsonConvert.DeserializeObject<Engine>(html).WebPages.TotalEstimatedMatches;
            else if (this.Name == "Google") this.TotalResults = JsonConvert.DeserializeObject<Engine>(html).SearchInformation.TotalResults;

            return this.TotalResults;

        }
    }

    public class Webpages
    {
        public int TotalEstimatedMatches { get; set; }
    }

    public class Searchinformation
    {
        public int TotalResults { get; set; }
    }
}
