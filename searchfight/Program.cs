namespace searchfight
{
    class Program
    {
        static void Main(string[] searchArguments)
        {
            SearchEngineManager engines = new SearchEngineManager();
            ResultsCalculator results = new ResultsCalculator(engines, searchArguments);
            ResultsOutputter output = new ResultsOutputter(results);
            output.PrintWinnersToConsole();
        }
    }
}
