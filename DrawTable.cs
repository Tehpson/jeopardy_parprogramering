 using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Dynamic;
using System.Threading;
using System.Runtime.CompilerServices;

namespace jeopardy_par_programering
{
    class DrawTable
    {

        //diffreant stages of game
        enum Stage
        {
            Start, 
            PlayerCount,
            PlayerName,
            Board,
            Answer,
            Question,
        }
        //where cureses is
        private static int[] activebord = { 0, 1 };
        private static int activePlayerCount = 2;
        private static int activeAnswerCuror = 0;
        private static int qestionID;
        private static string fastestPlayerName = "";
        //lsit of the playername that we send to game.cs
        private static List<string> players = new List<string>();
        public static void draw()
        {
            //set that we start with staret
            Stage state = Stage.Start;

            //so the game dosn't cloase
            while (true)
            {
                Console.Clear();

                //see waht state we are in
                switch (state)
                {
                    //just wirte out in the conosol
                    case Stage.Start:
                        players.Clear();
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 5); Console.Write(@"               _                            _               _                                _       ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 6); Console.Write(@"              | |                          | |             | |                              | |      ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 7); Console.Write(@" __      _____| | ___ ___  _ __ ___   ___  | |_ ___        | | __ _ _ __   ___   ___ _ __ __| |_   _ ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 8); Console.Write(@" \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \   _   | |/ _` | '_ \ / _ \ / _ \ '__/ _` | | | |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 9); Console.Write(@"  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |__| | (_| | |_) | (_) |  __/ | | (_| | |_| |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 10); Console.Write(@"   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \____/ \__,_| .__/ \___/ \___|_|  \__,_|\__, |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 11); Console.Write(@"                                                                   | |                          __/ |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 12); Console.Write(@"                                                                   |_|                         |___/ ");


                        Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.WindowHeight - 10); Console.WriteLine(">  Start");

                        //juat make this to have it wait for an input
                        _ = Console.ReadKey().Key;
                        break;

                        //choos ho many players
                    case Stage.PlayerCount:
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 5); Console.Write(@"  _    _                                                     _                          ___  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 6); Console.Write(@" | |  | |                                                   | |                        |__ \ ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 7); Console.Write(@" | |__| | _____      __  _ __ ___   __ _ _ __  _   _   _ __ | | __ _ _   _  ___ _ __ ___  ) |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 8); Console.Write(@" |  __  |/ _ \ \ /\ / / | '_ ` _ \ / _` | '_ \| | | | | '_ \| |/ _` | | | |/ _ \ '__/ __|/ / ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 9); Console.Write(@" | |  | | (_) \ V  V /  | | | | | | (_| | | | | |_| | | |_) | | (_| | |_| |  __/ |  \__ \_|  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 10); Console.Write(@" |_|  |_|\___/ \_/\_/   |_| |_| |_|\__,_|_| |_|\__, | | .__/|_|\__,_|\__, |\___|_|  |___(_)  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 11); Console.Write(@"                                                __/ | | |             __/ |                  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 46, 12); Console.Write(@"                                               |___/  |_|            |___/                   ");


                        for (int i = 2; i < 5;  i++)
                        {
                            int numberColum = (Console.WindowWidth / 4 * (i-1));
                            //if the curser is on teh same as we write out jsut worte out > before 
                            if (activePlayerCount == i)
                            {
                                Console.SetCursorPosition(numberColum - 4, Console.WindowHeight - 10);
                                Console.Write(" >  ");
                            }
                            Console.SetCursorPosition(numberColum, Console.WindowHeight - 10); Console.WriteLine(i);
                        }

                        break;


                        //let teh player choos player name
                    case Stage.PlayerName:
                        for (int i = 0; i < activePlayerCount ; i++)
                        {
                            bool nameDone = false;
                            string name = "";
                            //loop until the palyer have neterd full name
                            while (!nameDone)
                            {
                                Console.Clear();
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 5); Console.Write(@"  ______       _                    _                         _   _                      ");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 6); Console.Write(@" |  ____|     | |                  | |                       | \ | |                     ");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 7); Console.Write(@" | |__   _ __ | |_ ___ _ __   _ __ | | __ _ _   _  ___ _ __  |  \| | __ _ _ __ ___   ___ ");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 8); Console.Write(@" |  __| | '_ \| __/ _ \ '__| | '_ \| |/ _` | | | |/ _ \ '__| | . ` |/ _` | '_ ` _ \ / _ \");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 9); Console.Write(@" | |____| | | | ||  __/ |    | |_) | | (_| | |_| |  __/ |    | |\  | (_| | | | | | |  __/");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 10); Console.Write(@" |______|_| |_|\__\___|_|    | .__/|_|\__,_|\__, |\___|_|    |_| \_|\__,_|_| |_| |_|\___|");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 11); Console.Write(@"                             | |             __/ |                                       ");
                                Console.SetCursorPosition((Console.WindowWidth / 2) - 45, 12); Console.Write(@"                             |_|            |___/                                        ");

                                
                                Console.SetCursorPosition((Console.WindowWidth / 2) - name.Length / 2, Console.WindowHeight - 10); Console.WriteLine(name);

                                var localinput = Console.ReadKey();
                                //if the charcter is a letter at the charicter to the name
                                if (Char.IsLetter(localinput.KeyChar))
                                {
                                    name = name + localinput.Key;

                                } // if the inputed key is enter key stop teh loop and add teh name to the player list 
                                else if (localinput.Key == ConsoleKey.Enter)
                                {
                                    nameDone = true;
                                    players.Add(name);
                                }
                            }
                        }
                        break;



                        //draw the game board
                    case Stage.Board:
                        //write out what buton to play.
                        if (gameLogic.players.Count == 2)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is P");
                        }
                        else if (gameLogic.players.Count == 3)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is V     " + gameLogic.players[2].Name + " button is P     ");
                        }
                        else if (gameLogic.players.Count == 4)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is Z" + gameLogic.players[2].Name + " button is M     " + gameLogic.players[3].Name + " button is P     ");
                        }
                        //for each cat
                        for (int i = 0; i < 6; i++)
                        {
                            int value = 0;
                            int catColum = (Console.WindowWidth /7 * (i + 1)) - (questions.question_list[i].category.Length / 2);
                            int pointcolum = (Console.WindowWidth / 7 * (i + 1) - 2);
                            Console.SetCursorPosition(catColum, Console.WindowHeight / 7);
                            Console.Write(questions.question_list[i].category);
                            //for each row of question
                            for (int y = 1; y < 6; y++)
                            {
                                switch (y)
                                {
                                    case 1:
                                        if (!questions.dataList[questions.question_list[i].question1ID].done)
                                        {

                                            value = questions.dataList[questions.question_list[i].question1ID].value;
                                        }
                                        else
                                        {
                                            value = 0;
                                        }
                                        break;
                                    case 2:
                                        if (!questions.dataList[questions.question_list[i].question2ID].done)
                                        {

                                            value = questions.dataList[questions.question_list[i].question2ID].value;
                                        }
                                        else
                                        {
                                            value = 0;
                                        }
                                        break;
                                    case 3:
                                        if (!questions.dataList[questions.question_list[i].question3ID].done)
                                        {

                                            value = questions.dataList[questions.question_list[i].question3ID].value;
                                        }
                                        else
                                        {
                                            value = 0;
                                        }
                                        break;
                                    case 4:
                                        if (!questions.dataList[questions.question_list[i].question4ID].done)
                                        {

                                            value = questions.dataList[questions.question_list[i].question4ID].value;
                                        }
                                        else
                                        {
                                            value = 0;
                                        }
                                        break;
                                    case 5:
                                        if (!questions.dataList[questions.question_list[i].question5ID].done)
                                        {

                                            value = questions.dataList[questions.question_list[i].question5ID].value;
                                        }
                                        else
                                        {
                                            value = 0;
                                        }
                                        break;
                                }
                                //if value is bettwen 600 and 1000 just reduce by 500 to get the rigth vlau. (in round two do the opesist)
                                if (value > 500) value = value - 500;
                                //if curser is on teh current question add > before it
                                if (activebord[0] == i && activebord[1] == y)
                                {
                                    Console.SetCursorPosition(pointcolum-4, Console.WindowHeight / 8 * (y + 1));
                                    Console.Write(" >  ");
                                }
                                Console.SetCursorPosition(pointcolum, Console.WindowHeight / 8 * (y + 1));
                                //if the question is already answered disaply empty
                                if (value != 0)
                                {
                                    Console.Write(value);
                                }

                            }

                        }

                        //write out the player with theier scor at the end of the screen
                        int currentPlayer = 1;
                        foreach (var player in gameLogic.players)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / (gameLogic.players.Count + 1) * currentPlayer - player.Name.Length / 2, (Console.WindowHeight / 8) * 7);
                            Console.Write(player.Name);
                            Console.SetCursorPosition(Console.WindowWidth / (gameLogic.players.Count + 1) * currentPlayer - 2, (Console.WindowHeight / 8) * 7 + 1);
                            Console.Write(player.Points);
                            currentPlayer++;
                        }

                        break;

                    case Stage.Question:

                        //write out what buton to play.
                        if (gameLogic.players.Count == 2)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is P");
                        }
                        else if (gameLogic.players.Count == 3)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is V     " + gameLogic.players[2].Name + " button is P     ");
                        }
                        else if (gameLogic.players.Count == 4)
                        {
                            Console.WriteLine(gameLogic.players[0].Name + " button is Q     " + gameLogic.players[1].Name + " button is Z" + gameLogic.players[2].Name + " button is M     " + gameLogic.players[3].Name + " button is P     ");
                        }


                        bool questionsActive = true;
                        //we have to use the answer here co< its jepoardy
                        string question = questions.dataList[qestionID].answer;

                        //uses this wile so if they press the wrongbutton we still coinue unitl somone presssed the rigth one.
                        while (questionsActive)
                        {
                            Console.SetCursorPosition((Console.WindowWidth / 2) - (question.Length / 2), Console.WindowHeight / 2);
                            Console.Write(question);
                            //to set teh cursour out fo the way
                            Console.SetCursorPosition(0, Console.WindowHeight-1);

                            var fastestPlayInput = Console.ReadKey().Key;
                            //Q spoelare 1, Z spelare 2, M spelare 3, P sepaler 4
                            switch (activePlayerCount)
                            {
                                case 2:
                                    if(fastestPlayInput == ConsoleKey.Q)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[0].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[0].Name);
                                        fastestPlayerName = gameLogic.players[0].Name;
                                         questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.P)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[1].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[1].Name);
                                        fastestPlayerName = gameLogic.players[1].Name;
                                        questionsActive = false;
                                    }
                                    break;
                                case 3:
                                    if (fastestPlayInput == ConsoleKey.Q)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[0].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[0].Name);
                                        fastestPlayerName = gameLogic.players[0].Name;
                                        questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.V)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[1].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[1].Name);
                                        fastestPlayerName = gameLogic.players[1].Name;
                                        questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.P)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[2].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[2].Name);
                                        fastestPlayerName = gameLogic.players[2].Name;
                                        questionsActive = false;
                                    }
                                    break;
                                case 4:
                                    if (fastestPlayInput == ConsoleKey.Q)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[0].Name.Length +14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " +gameLogic.players[0].Name);
                                        fastestPlayerName = gameLogic.players[0].Name;
                                        questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.Z)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[1].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[1].Name);
                                        fastestPlayerName = gameLogic.players[1].Name;
                                        questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.M)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[2].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[2].Name);
                                        fastestPlayerName = gameLogic.players[2].Name;
                                        questionsActive = false;
                                    }
                                    if (fastestPlayInput == ConsoleKey.P)
                                    {
                                        Console.SetCursorPosition(Console.WindowWidth / 2 - ((gameLogic.players[3].Name.Length+14) / 2), Console.WindowHeight - 10);
                                        Console.Write("Fastes Player: " + gameLogic.players[3].Name);
                                        fastestPlayerName = gameLogic.players[3].Name;
                                        questionsActive = false;
                                    }
                                    break;
                            }
                        }
                        //to set teh cursour out fo the way
                        Console.SetCursorPosition(0, Console.WindowHeight - 1);
                        //make sure that even if palyers press a lot of buttons after the first one it dosnt skip evrything
                        Console.WriteLine("press Enter to Continue");
                        _ = Console.ReadLine();
                        break;

                        //juast dispaly the answer 
                    case Stage.Answer:
                        //we have to use the question here czo its jepoardy
                        string answer = questions.dataList[qestionID].question;
                        Console.SetCursorPosition((Console.WindowWidth / 2) - (answer.Length / 2), Console.WindowHeight / 2);
                        Console.Write(answer);
                        Console.SetCursorPosition(Console.WindowWidth / 4 -10, Console.WindowHeight - 10);
                        Console.Write("Was the answer rigth?");
                        if (activeAnswerCuror == 0)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 4 * 2 - 5, Console.WindowHeight - 10);
                            Console.Write(">");
                        }
                        Console.SetCursorPosition(Console.WindowWidth / 4 * 2 -1, Console.WindowHeight - 10);
                        Console.Write("YES");
                        if (activeAnswerCuror == 1)
                        {
                            Console.SetCursorPosition(Console.WindowWidth / 4 * 3 - 5, Console.WindowHeight - 10);
                            Console.Write(">");
                        }
                        Console.SetCursorPosition(Console.WindowWidth / 4 * 3 -1, Console.WindowHeight - 10);
                        Console.Write("NO");

                        //to get teh cursour out of teh way
                        Console.SetCursorPosition(0, Console.WindowHeight);
                        break;

                }


                //logic

                
            }
        }
    }
}
