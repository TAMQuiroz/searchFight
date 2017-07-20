using System;

namespace searchfight
{
    /* This class is in charge of the outputting of the results from the result calculator to a defined format. 
     * If a different kind of output is needed, it should be added here
     */
     
    class ResultsOutputter
    {
        private Result [] results;

        public ResultsOutputter(ResultsCalculator results)
        {
            this.results = results.Results;
        }

        internal void PrintWinnersToConsole()
        {
            //Prints the Result Winners array from ResultsCalculator
            for (int i = 0; i < this.results.Length - 1; i++)
            {
                Console.Write(this.results[i].GetEngineName() + " winner: ");
                if (this.results[i].GetResultNumber() != -1)
                    Console.WriteLine(this.results[i].GetArgumentName() + "\n");
                else
                    Console.WriteLine("No winner\n");
            }

            //Overall winner is stored in the last space of the Results Winners array from ResultsCalculator
            Console.Write("Total winner: ");

            if (this.results[this.results.Length - 1].GetResultNumber() != -1)
                Console.WriteLine(this.results[this.results.Length - 1].GetArgumentName() + "\n");
            else
                Console.WriteLine("No winner\n");

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
