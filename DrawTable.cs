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
        private static int activePlayerCount = 1;
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

                        break;


                    case Menu.PlayerCount:
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 5); Console.Write(@"  _    _                                                     _                          ___  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 6); Console.Write(@" | |  | |                                                   | |                        |__ \ ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 7); Console.Write(@" | |__| | _____      __  _ __ ___   __ _ _ __  _   _   _ __ | | __ _ _   _  ___ _ __ ___  ) |");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 8); Console.Write(@" |  __  |/ _ \ \ /\ / / | '_ ` _ \ / _` | '_ \| | | | | '_ \| |/ _` | | | |/ _ \ '__/ __|/ / ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 9); Console.Write(@" | |  | | (_) \ V  V /  | | | | | | (_| | | | | |_| | | |_) | | (_| | |_| |  __/ |  \__ \_|  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 10); Console.Write(@" |_|  |_|\___/ \_/\_/   |_| |_| |_|\__,_|_| |_|\__, | | .__/|_|\__,_|\__, |\___|_|  |___(_)  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 11); Console.Write(@"                                                __/ | | |             __/ |                  ");
                        Console.SetCursorPosition((Console.WindowWidth / 2) - 41, 12); Console.Write(@"                                               |___/  |_|            |___/                   ");

                        for (int i = 1; i < 4;  i++)
                        {

                            int numberColum = (Console.WindowWidth / 4 * (i));
                            if (activePlayerCount == i)
                            {
                                Console.SetCursorPosition(numberColum - 4, Console.WindowHeight - 10);
                                Console.Write(" >  ");
                            }
                            Console.SetCursorPosition(numberColum, Console.WindowHeight - 10); Console.WriteLine(i +1);
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
                var input = Console.ReadKey().Key;
                if(state == Menu.Start)
                {
                    state = Menu.PlayerCount;
                }


                if (state == Menu.PlayerCount)
                {
                    switch (input)
                    {
                        case ConsoleKey.RightArrow:
                            if(activePlayerCount < 3)
                            {
                                activePlayerCount++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (activePlayerCount > 1)
                            {
                                activePlayerCount--;
                            }
                            break;
                    }
                }

                if (state == Menu.board)
                {
                    switch (input)
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
                }
            }
        }
    }
}
