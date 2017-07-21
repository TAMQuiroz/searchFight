using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace searchfight
{
    class GoogleSearchEngine : SearchEngine
    {
        private string name;
        private string searchEngineUrl;
        private long totalResults;

        public GoogleSearchEngine()
        {
            var googleApiKey = "AIzaSyBHNafIEDb4gd2JmnEgieVSzM6eqhp71iQ";
            var googleEngineID = "015891582885684423708:95gpcjavrik";

            this.name = "Google";
            this.searchEngineUrl = "https://www.googleapis.com/customsearch/v1?key=" + googleApiKey + "&cx=" + googleEngineID + "&q=";
        }

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public string GetSearchEngineUrl()
        {
            return searchEngineUrl;
        }

        public void SetSearchEngineUrl(string value)
        {
            searchEngineUrl = value;
        }

        public long GetTotalResults()
        {
            return totalResults;
        }

        public void SetTotalResults(long value)
        {
            totalResults = value;
        }

        public void GenerateRequest(string searchArgument)
        {
            var url = this.GetSearchEngineUrl() + searchArgument;
            var request = (HttpWebRequest)WebRequest.Create(url);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.SetTotalResults(JsonConvert.DeserializeObject<GoogleSearchEngine>(html).SearchInformation.TotalResults);
        }

        public Searchinformation SearchInformation { get; set; }
    }

    public class Searchinformation
    {
        public long TotalResults { get; set; }
    }
}
