using System;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

namespace jeopardy_par_programering
{
    class Program
    {
        static void Main(string[] args)
        {
            bool sucseed = false;
            string season;


            while (!sucseed)
            {
                Console.Write("witch sesong do you wanan play you can choos between season 1 and 36: \t");
                season = Console.ReadLine();
                //set up the data to match the season that was choosen
                sucseed =  questions.setupData(season);
            }
            

        }
    }
}
