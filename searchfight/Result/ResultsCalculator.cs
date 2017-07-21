using System;
using System.Collections;

namespace searchfight
{
    class ResultsCalculator
    {
        private Result[] results;

        internal Result[] Results { get => results; set => results = value; }

        public ResultsCalculator(ArrayList engines, string[] searchArguments)
        {
            if(searchArguments.Length == 0)
            {
                Console.WriteLine("This program needs at least one argument. Press any key to continue...");
                Console.ReadKey();
                System.Environment.Exit(1);
            }
                
            this.results = new Result[engines.Count + 1];
            for (var i = 0; i <= engines.Count; i++) results[i] = new Result();
            this.FightEngines(engines, searchArguments);
        }

        public Result GetResult(int index)
        {
            return results[index];
        }

        public void SetResult(int index, long resultNumber, string argumentName, string engineName)
        {
            results[index].SetResultNumber(resultNumber);
            results[index].SetArgumentName(argumentName);
            results[index].SetEngineName(engineName);
        }

        private void FightEngines(ArrayList engines, string[] searchArguments)
        {
            for (int i = 0; i < searchArguments.Length; i++)
            {
                Console.Write(searchArguments[i] + ": ");

                for (int j = 0; j < engines.Count; j++)
                {
                    var engine = (SearchEngine)engines[j];
                    engine.GenerateRequest(searchArguments[i]);

                    Console.Write(engine.GetName() + ": " + engine.GetTotalResults() + " ");

                    if (engine.GetTotalResults() > results[j].GetResultNumber())
                        this.SetResult(j, engine.GetTotalResults(), searchArguments[i], engine.GetName());

                    //For the overall winner
                    if (engine.GetTotalResults() > results[engines.Count].GetResultNumber())
                        this.SetResult(engines.Count, engine.GetTotalResults(), searchArguments[i], engine.GetName());
                }

                Console.WriteLine("\n");
            }
        }
    }
}
