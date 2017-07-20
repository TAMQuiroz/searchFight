using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        {
            Engine google = new Engine();
            google.Name = "Google";
            google.ConnectionString = "https://www.googleapis.com/customsearch/v1?key=AIzaSyBHNafIEDb4gd2JmnEgieVSzM6eqhp71iQ&cx=015891582885684423708:95gpcjavrik&q=";

            Engine bing = new Engine();
            bing.Name = "Bing";
            bing.ConnectionString = "https://api.cognitive.microsoft.com/bing/v5.0/search?q=";

            Engine[] engines = new Engine[] { google, bing };

            int [,] enginesResult   =   InitializeEnginesResult(engines.Length);

            for (int i = 0; i < args.Length; i++){
                Console.Write(args[i] + ": ");

                for (int j = 0; j < engines.Length; j++)
                {
                    engines[j].Request(args[i]);

                    Console.Write(engines[j].Name + ": " + engines[j].TotalResults + " ");

                    if (engines[j].TotalResults > enginesResult[j, 0])
                    {
                        enginesResult[j,0] = engines[j].TotalResults;
                        enginesResult[j,1] = i;
                    }
                    
                    if (engines[j].TotalResults > enginesResult[engines.Length, 0])
                    {
                        enginesResult[engines.Length, 0] = engines[j].TotalResults;
                        enginesResult[engines.Length, 1] = i;
                    }
                }

                Console.WriteLine("\n");
            }    
             
            PrintWinners(engines, enginesResult, args);

            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }

        private static void PrintWinners(Engine[] engines, int [,] enginesResult, string [] args)
        {
            for (int i = 0; i < enginesResult.GetLength(0) - 1; i++) {
                Console.Write(engines[i].Name + " winner: ");
                if(enginesResult[i,0] != -1) 
                    Console.WriteLine(args[enginesResult[i, 1]] + "\n");
                else
                    Console.WriteLine("No winner\n");
            }

            Console.Write("Total winner: ");
            if (enginesResult[engines.GetLength(0), 1] != -1)
                Console.WriteLine(args[enginesResult[engines.GetLength(0), 1]] + "\n");
            else
                Console.WriteLine("No winner\n");
        }

        private static int [,] InitializeEnginesResult(int enginesNumber)
        {
            int [,] enginesResult = new int [enginesNumber + 1, 2];
            
            for (var i = 0; i <= enginesNumber; i++)
            {
                enginesResult[i,0] = -1;    //Number of results
                enginesResult[i,1] = -1;    //Arg
            }
            
            return enginesResult;
        }

    }
}
