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
            Console.Clear();
            Console.WriteLine("\n\n-----------------Welcome to Jeopardy!-----------------");
            Console.WriteLine("\n------------------------------------------------------");
            Console.WriteLine("\n ");
            Console.Write("\t\t How many players?");
            string playerNum = Console.ReadLine();

            Console.WriteLine("Loading...");
            bool sucseed = questions.setupData();
            Console.Clear();
            if (!sucseed)
            {
                Console.WriteLine("ERROR while eating up data...");
            }

            //Ska vi köra typ en sån här switch som hoppar in i antalet spelare? där antalet spelare som
            //har en egen method som kallar på dem andra programmen baserat på antalet spelare?
            switch (playerNum)
            {
                case "1":
                    OnePlayer();
                    return true;
                case "2":
                    TwoPlayers();
                    return true;
                case "3":
                    ThreePlayers();
                    return true;
                case "4":
                    FourPlayers();
                    return true;
                default:
                    Console.WriteLine("No players, program closes");
                    return false;
            }



                    // draw up the game board. 
                    //ska vi gör aså att man kan välja hur många man 
                    // vill köra liksom köra 2 eller flera. tänker att man bara gör funktioner som man kallar på.
                    // eller om jag mins rätt så gäller det att vara snabbat oxå så vi typ gör att
                    //alla får varsin knapp på tangetbordet och sedan kollar man vilken knapp som blev nertryckt snabbast
                    // med hjälp av Console.ReadKey(); funktionen?

            }
    }
}
