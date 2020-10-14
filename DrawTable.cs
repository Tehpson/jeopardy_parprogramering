﻿using System;
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
            playrname,
            board,
        }
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

                    case Menu.board:
                        for (int i = 0; i < 6; i++)
                        {
                            int value = 0;
                            int catColum = (Console.WindowWidth / 7 * (i + 1)) - (questions.question_list[i].category.Length / 2);
                            int pointcolum = (Console.WindowWidth / 7 * (i + 1) - 2);
                            Console.SetCursorPosition(catColum, Console.WindowHeight / 7);
                            Console.WriteLine(questions.question_list[i].category);

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
                                Console.SetCursorPosition(pointcolum, Console.WindowHeight / 7 * (y+1));
                                if (value > 500) value = value - 500;
                                Console.WriteLine(value);
                            }

                        }
                        break;
                }

                
                Console.ReadKey();
                if(state == Menu.Start)
                {
                    state = Menu.board;
                }
            }
        }
    }
}