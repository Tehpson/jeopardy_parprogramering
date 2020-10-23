using System;

namespace jeopardy_par_programering
{
    class Program
    {
        static void Main(string[] args)
        {

            //This have to be the highest in teh file coz we want to do this before evrything else.

            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            Console.SetWindowPosition(0, 0);
            Console.WriteLine("Loading...");
            bool sucseed = questions.setUpData();
            Console.Clear();
            if (!sucseed)
            {
                Console.WriteLine("ERROR while setting up data...\n please Restart");
                Environment.Exit(0);
            }

            //Game
            DrawTable.draw();
        }
    }
}
