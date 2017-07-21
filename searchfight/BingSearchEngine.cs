using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;

namespace searchfight
{
    class BingSearchEngine : SearchEngine
    {
        private string name;
        private string apiKey;
        private string searchEngineUrl;
        private long totalResults;

        public BingSearchEngine()
        {
            this.name = "Bing";
            this.apiKey = "793a9b2348994fcfb54a55f2eb09a2ee";
            this.searchEngineUrl = "https://api.cognitive.microsoft.com/bing/v5.0/search?q=";
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
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.apiKey);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.SetTotalResults(JsonConvert.DeserializeObject<BingSearchEngine>(html).WebPages.TotalEstimatedMatches);

        }

        public Webpages WebPages { get; set; }
    }


    public class Webpages
    {
        public long TotalEstimatedMatches { get; set; }
    }
}
