using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace searchfight
{
    class GoogleSearchEngine : ISearchEngine
    {
        private string name;
        private string searchEngineUrl;
        private long totalResults;

        public GoogleSearchEngine()
        {
            var googleApiKey = "AIzaSyBHNafIEDb4gd2JmnEgieVSzM6eqhp71iQ";
            var googleEngineID = "015891582885684423708:95gpcjavrik";
            this.Name = "Google";
            this.SearchEngineUrl = "https://www.googleapis.com/customsearch/v1?key=" + googleApiKey + "&cx=" + googleEngineID + "&q=";
        }

        public string Name { get => name; set => name = value; }
        public string SearchEngineUrl { get => searchEngineUrl; set => searchEngineUrl = value; }
        public long TotalResults { get => totalResults; set => totalResults = value; }

        public void GenerateRequest(string searchArgument)
        {
            var url = this.SearchEngineUrl + searchArgument;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.TotalResults = JsonConvert.DeserializeObject<GoogleSearchEngine>(html).SearchInformation.TotalResults;
        }

        public Searchinformation SearchInformation { get; set; }

    }

    public class Searchinformation
    {
        public long TotalResults { get; set; }
    }
}
