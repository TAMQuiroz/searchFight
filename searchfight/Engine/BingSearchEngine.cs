using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace searchfight
{
    class BingSearchEngine : ISearchEngine
    {
        private string name;
        private string apiKey;
        private string searchEngineUrl;
        private long totalResults;

        public BingSearchEngine()
        {
            this.Name = "Bing";
            this.ApiKey = "793a9b2348994fcfb54a55f2eb09a2ee";
            this.SearchEngineUrl = "https://api.cognitive.microsoft.com/bing/v5.0/search?q=";
        }

        public string Name { get => name; set => name = value; }
        public string ApiKey { get => apiKey; set => apiKey = value; }
        public string SearchEngineUrl { get => searchEngineUrl; set => searchEngineUrl = value; }
        public long TotalResults { get => totalResults; set => totalResults = value; }
        
        public void GenerateRequest(string searchArgument)
        {
            var url = this.SearchEngineUrl + searchArgument;
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("Ocp-Apim-Subscription-Key", this.ApiKey);
            var response = (HttpWebResponse)request.GetResponse();
            var stream = response.GetResponseStream();
            var reader = new StreamReader(stream);
            var html = reader.ReadToEnd();
            this.TotalResults = JsonConvert.DeserializeObject<BingSearchEngine>(html).WebPages.TotalEstimatedMatches;

        }

        public Webpages WebPages { get; set; }

    }


    public class Webpages
    {
        public long TotalEstimatedMatches { get; set; }
    }
}
