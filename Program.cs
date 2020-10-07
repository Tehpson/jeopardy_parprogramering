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

            Console.WriteLine("Laoding...");
            bool sucseed = questions.setupData();
            Console.Clear();
            if (!sucseed)
            {
                Console.WriteLine("ERROR while eting up data...");
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
