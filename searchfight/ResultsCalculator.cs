using System;

namespace searchfight
{
    //This class is in charge of the calculation of the results of the search fight between the engines using the given arguments.
    class ResultsCalculator
    {
        //Constructor that creates the Result Winner array and fires the engine fight.
        public ResultsCalculator(Engine[] engines, string[] args)
        {
            this.results = new Result[engines.Length + 1];
            for (var i = 0; i <= engines.Length; i++) results[i] = new Result();
            this.FightEngines(engines, args);
        }

        private Result[] results;

        internal Result[] Results { get => results; set => results = value; }

        public Result GetResult(int index)
        {
            return results[index];
        }

        public void SetResult(int index, int resultNumber, string argumentName, string engineName)
        {
            results[index].SetResultNumber(resultNumber);
            results[index].SetArgumentName(argumentName);
            results[index].SetEngineName(engineName);
        }

        /* A request is made for each argument passed and for every engine managed. 
         * The engine with the highest number of results for an argument is stored
         * in the results array until there is no more engines to be consulted or 
         * arguments to be searched. The overall winner is searched at the same time
         * as well.
         */

        private void FightEngines(Engine[] engines, string[] arguments)
        {
            for (int i = 0; i < arguments.Length; i++)
            {
                Console.Write(arguments[i] + ": ");

                for (int j = 0; j < engines.Length; j++)
                {
                    engines[j].Request(arguments[i]);

                    Console.Write(engines[j].GetName() + ": " + engines[j].GetTotalResults() + " ");

                    //For the engine
                    if (engines[j].GetTotalResults() > results[j].GetResultNumber())
                        this.SetResult(j, engines[j].GetTotalResults(), arguments[i], engines[j].GetName());

                    //For the overall winner
                    if (engines[j].GetTotalResults() > results[engines.Length].GetResultNumber())
                        this.SetResult(engines.Length, engines[j].GetTotalResults(), arguments[i], engines[j].GetName());
                }

                Console.WriteLine("\n");
            }
        }
    }
}
