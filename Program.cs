﻿using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;

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

            DrawTable.draw();

            //I am thinking will be doing aslittle code as posible in this file 
            //Console.WriteLine("\n\n-----------------Welcome to Jeopardy!-----------------");
            //Console.WriteLine("\n------------------------------------------------------");
            //Console.WriteLine("\n ");
            //Console.Write("\t\t How many players?");
            //string playerNum = Console.ReadLine();



            //My thougth

            //I saty we have to say the players/team must be between like 2 and 5, ould be are to play alone.
            //instead of making one function per player make one function that loop for that many player
            //game.setupPlayer(playerNum);
            //switch (playerNum)
            //{
            //    case "1":
            //        // jag säger at min måste välja mellan 2 och 5 spelare typ för svårt att spela det själv
            //        //istället för att göra en funtion där anta lspelare så gör enfuntion som du sickar med hur många spelare
            //        //som sedan loppar så många gånger och även frågar vad lagnamnet ska vara
            //        OnePlayer();
            //        return true;
            //    case "2":
            //        TwoPlayers();
            //        return true;
            //    case "3":
            //        ThreePlayers();
            //        return true;
            //    default:
            //        Console.WriteLine("No players, program closes");
            //        return false;
            //}


            //debug code
            Console.WriteLine("Catigories");
            foreach (var data in questions.question_list)
            {
                Console.WriteLine(data.category);
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
