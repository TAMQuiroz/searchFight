using Newtonsoft.Json;
using System.IO;
using System.Net;

namespace searchfight
{
    //This class is in charge of the requests to a certain search engine and storing the query response information in its atributes.
    class Engine
    {
        public Engine(string Name, string ConnectionString)
        {
            this.name = Name;
            this.connectionString = ConnectionString;
        }

        private string name;
        private string connectionString;
        private int totalResults;

        public string GetName()
        {
            return name;
        }

        public void SetName(string value)
        {
            name = value;
        }

        public string GetConnectionString()
        {
            return connectionString;
        }

        public void SetConnectionString(string value)
        {
            connectionString = value;
        }

        public int GetTotalResults()
        {
            return totalResults;
        }

        public void SetTotalResults(int value)
        {
            totalResults = value;
        }

        // If more tweaking is needed, it should be done here.
        public void Request(string arg)
        {
            //Setting the search query
            string url = this.GetConnectionString() + arg;
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            if (this.GetName() == "Bing") request.Headers.Add("Ocp-Apim-Subscription-Key", "793a9b2348994fcfb54a55f2eb09a2ee");

            //Sending request and asking for a response
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader reader = new StreamReader(stream);
            string html = reader.ReadToEnd();

            //Parsing depending on JSON request of engine API
            if (this.GetName() == "Bing") this.SetTotalResults(JsonConvert.DeserializeObject<Engine>(html).WebPages.TotalEstimatedMatches);
            else if (this.GetName() == "Google") this.SetTotalResults(JsonConvert.DeserializeObject<Engine>(html).SearchInformation.TotalResults);

        }

        //Properties need for the response of each engine
        public Webpages WebPages { get; set; }

        public Searchinformation SearchInformation { get; set; }

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
