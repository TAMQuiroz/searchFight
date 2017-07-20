using System;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine[] engines = InitializeEngines();
            ResultsCalculator results = new ResultsCalculator(engines, args);
            ResultsOutputter output = new ResultsOutputter(results);
            output.PrintWinnersToConsole();
        }

        private static Engine[] InitializeEngines()
        {
            /* In case an additional search engine is needed, here is the place to add it. 
             * If more tweaking is needed, it should be done in the Engine class.
             */

            Engine google = new Engine("Google", "https://www.googleapis.com/customsearch/v1?key=AIzaSyBHNafIEDb4gd2JmnEgieVSzM6eqhp71iQ&cx=015891582885684423708:95gpcjavrik&q=");
            Engine bing = new Engine("Bing", "https://api.cognitive.microsoft.com/bing/v5.0/search?q=");

            return new Engine[] { google, bing };
        }

    }
}
