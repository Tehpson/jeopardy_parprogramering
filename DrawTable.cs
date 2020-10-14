using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Dynamic;

namespace jeopardy_par_programering
{
    class DrawTable
    {
        enum Menu
        {
            Start, 
            PlayerCount,
            PlayerName,
            board,
        }
        private static int[] activebord = { 0, 1 };
        private static int activePlayerCount = 2;
        private static List<string> players = new List<string>();
        public static void draw()
        {
            
            Menu state = Menu.Start;
            while (true)
            {
                Console.Clear();
                switch (state)
                {
                    case Menu.Start:

                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 5); Console.Write(@"               _                            _               _                                _       ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 6); Console.Write(@"              | |                          | |             | |                              | |      ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 7); Console.Write(@" __      _____| | ___ ___  _ __ ___   ___  | |_ ___        | | __ _ _ __   ___   ___ _ __ __| |_   _ ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 8); Console.Write(@" \ \ /\ / / _ \ |/ __/ _ \| '_ ` _ \ / _ \ | __/ _ \   _   | |/ _` | '_ \ / _ \ / _ \ '__/ _` | | | |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 9); Console.Write(@"  \ V  V /  __/ | (_| (_) | | | | | |  __/ | || (_) | | |__| | (_| | |_) | (_) |  __/ | | (_| | |_| |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 10); Console.Write(@"   \_/\_/ \___|_|\___\___/|_| |_| |_|\___|  \__\___/   \____/ \__,_| .__/ \___/ \___|_|  \__,_|\__, |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 11); Console.Write(@"                                                                   | |                          __/ |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 50, 12); Console.Write(@"                                                                   |_|                         |___/ ");


                        Console.SetCursorPosition((Console.WindowWidth / 2) - 5, Console.WindowHeight - 10); Console.WriteLine(">  Start");

                        _ = Console.ReadKey().Key;
                        break;


                    case Menu.PlayerCount:
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
                            if (activePlayerCount == i)
                            {
                                Console.SetCursorPosition(numberColum - 4, Console.WindowHeight - 10);
                                Console.Write(" >  ");
                            }
                            Console.SetCursorPosition(numberColum, Console.WindowHeight - 10); Console.WriteLine(i);
                        }

                        break;



                    case Menu.PlayerName:
                        for (int i = 0; i < activePlayerCount ; i++)
                        {
                            bool nameDone = false;
                            string name = "";
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
                                if (Char.IsLetter(localinput.KeyChar))
                                {
                                    name = name + localinput.Key;
                                }else if (localinput.Key == ConsoleKey.Enter)
                                {
                                    nameDone = true;
                                    players.Add(name);
                                }
                            }
                        }
                        break;




                    case Menu.board:
                        for (int i = 0; i < 6; i++)
                        {
                            int value = 0;
                            int catColum = (Console.WindowWidth / 7 * (i + 1)) - (questions.question_list[i].category.Length / 2);
                            int pointcolum = (Console.WindowWidth / 7 * (i + 1) - 2);
                            Console.SetCursorPosition(catColum, Console.WindowHeight / 7);
                            Console.Write(questions.question_list[i].category);

                            for (int y = 1; y < 6; y++)
                            {
                                switch (y)
                                {
                                    case 1:
                                        value = questions.dataList[questions.question_list[i].question1ID].value;
                                        break;
                                    case 2:
                                        value = questions.dataList[questions.question_list[i].question2ID].value;
                                        break;
                                    case 3:
                                        value = questions.dataList[questions.question_list[i].question3ID].value;
                                        break;
                                    case 4:
                                        value = questions.dataList[questions.question_list[i].question4ID].value;
                                        break;
                                    case 5:
                                        value = questions.dataList[questions.question_list[i].question5ID].value;
                                        break;
                                }
                                if (value > 500) value = value - 500;
                                if (activebord[0] == i && activebord[1] == y)
                                {
                                    Console.SetCursorPosition(pointcolum-4, Console.WindowHeight / 7 * (y + 1));
                                    Console.Write(" >  ");
                                }
                                Console.SetCursorPosition(pointcolum, Console.WindowHeight / 7 * (y + 1));
                                Console.Write(value);
                            }

                        }
                        break;
                }


                //logic

                switch (state)
                {
                    case Menu.Start:
                        state = Menu.PlayerCount;
                        break;

                    case Menu.PlayerCount:

                        var inputplyaer = Console.ReadKey().Key;
                        switch (inputplyaer)
                        {
                            case ConsoleKey.RightArrow:
                                if (activePlayerCount < 4)
                                {
                                    activePlayerCount++;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (activePlayerCount > 2)
                                {
                                    activePlayerCount--;
                                }
                                break;

                            case ConsoleKey.Enter:
                                state = Menu.PlayerName;
                                break;
                        }
                        break;

                    case Menu.PlayerName:
                        state = Menu.board;
                        break;

                    case Menu.board:

                        var inputboard = Console.ReadKey().Key;
                        switch (inputboard)
                        {
                            case ConsoleKey.UpArrow:
                                if (activebord[1] > 1)
                                {
                                    activebord[1] = activebord[1] - 1;
                                }
                                break;
                            case ConsoleKey.DownArrow:
                                if (activebord[1] < 5)
                                {
                                    activebord[1] = activebord[1] + 1;
                                }
                                break;
                            case ConsoleKey.LeftArrow:
                                if (activebord[0] > 0)
                                {
                                    activebord[0] = activebord[0] - 1;
                                }
                                break;
                            case ConsoleKey.RightArrow:
                                if (activebord[0] < 5)
                                {
                                    activebord[0] = activebord[0] + 1;
                                }
                                break;
                            default:
                                break;
                        }
                        break;
                }
            }
        }
    }
}
