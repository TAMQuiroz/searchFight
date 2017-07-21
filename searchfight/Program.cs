using System.Collections;

namespace searchfight
{
    class Program
    {
        static void Main(string[] searchArguments)
        {
            GoogleSearchEngine google = new GoogleSearchEngine();
            BingSearchEngine bing = new BingSearchEngine();
            ArrayList engines = new ArrayList { google, bing };

            ResultsCalculator results = new ResultsCalculator(engines, searchArguments);
            ResultsOutputter output = new ResultsOutputter(results);
            output.PrintWinnersToConsole();
        }
    }
}
