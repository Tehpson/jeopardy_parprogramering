using System;
using System.Collections.Generic;
using System.Text;

namespace jeopardy_par_programering
{
    class gameLogic
    {
        public static List<Player> players = new List<Player>();

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

        /*      TODO:
         *      Function that add teh players to a playerlist
         *      Funtion that add or subtract score from the player
         */
        //idk tror inte vi beöhver detta då jag sickar till dig spelare och value och ifall det var rätt eller fel.  gör istället en void function som tar in stirng Name, int Value, bool answer
        
        // här gör att du ahr imot en lista med namn istället, och sedan för List.count loppar du till du har laggt in alla 
        //gör ändast void functioner då ci inte kommer behlva få tillbaka någon data när vi kllar på dem.

        /*public static void AddPlayers(List<string> playername)
        {
            foreach (var player in playername)
            {
                //sorry var jag som fukcade upp 
                players.Add(new Player { Name = player, Points = 0 });
            }
        }
    }*/
        // humm kan vara bra i slutet där man kollar vem som van. 
        public static int ComparePlayers(Player Name) { return 0; }

        //bara added denna du löser vad den gör
        internal static void addScore(string fastestPlayerName, int value, bool wasAnswerRigth)
        {
            
        }

        public static void GameState()
        {
            Stage state = Stage.Start;

            switch (state)
            {
                //change state from start to plci kplayer count
                case Stage.Start:
                    state = Stage.PlayerCount;
                    break;

                case Stage.PlayerCount:

                    var inputPlayer = Console.ReadKey().Key;
                    switch (inputPlayer)
                    {
                        //if we press the rigth button then we cahnge the cursor one step
                        case ConsoleKey.RightArrow:
                            if (activePlayerCount < 4)
                            {
                                activePlayerCount++;
                            }
                            break;
                        // if we press teh left button change the cursor to the left one step
                        case ConsoleKey.LeftArrow:
                            if (activePlayerCount > 2)
                            {
                                activePlayerCount--;
                            }
                            break;

                        //if enter conintu to plater name
                        case ConsoleKey.Enter:
                            state = Stage.PlayerName;
                            break;
                    }
                    break;

                //if all playername have been put in go to the game board
                case Stage.PlayerName:
                    state = Stage.Board;
                    gameLogic.AddPlayers(players);
                    break;


                case Stage.Board:

                    //look witch way the player change the curser.
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
                        case ConsoleKey.Enter:
                            var cat = activebord[0];
                            var question = activebord[1];
                            qestionID = 1;
                            switch (question)
                            {
                                case 1:
                                    qestionID = questions.question_list[cat].question1ID;
                                    break;
                                case 2:
                                    qestionID = questions.question_list[cat].question2ID;
                                    break;
                                case 3:
                                    qestionID = questions.question_list[cat].question3ID;
                                    break;
                                case 4:
                                    qestionID = questions.question_list[cat].question4ID;
                                    break;
                                case 5:
                                    qestionID = questions.question_list[cat].question5ID;
                                    break;
                            }
                            state = Stage.Question;
                            break;

                        default:
                            break;
                    }

                    break;

                case Stage.Question:
                    state = Stage.Answer;
                    break;


                case Stage.Answer:
                    var answerInput = Console.ReadKey().Key;
                    switch (answerInput)
                    {
                        case ConsoleKey.RightArrow:
                            if (activeAnswerCuror == 0)
                            {
                                activeAnswerCuror++;
                            }
                            break;
                        case ConsoleKey.LeftArrow:
                            if (activeAnswerCuror == 1)
                            {
                                activeAnswerCuror--;
                            }
                            break;
                        case ConsoleKey.Enter:
                            //sene to game.cs with playername and value of the question
                            bool wasAnswerRigth = false;
                            if (activeAnswerCuror == 0)
                                wasAnswerRigth = false;
                            else wasAnswerRigth = true;

                            gameLogic.addScore(fastestPlayerName, questions.dataList[qestionID].value, wasAnswerRigth);
                            state = Stage.Board;
                            break;
                    }
                    break;
            }
        }

        /* public static List<data> ComparePlayers(Player listName, Player player2, Player player3, Player player4)
         {
             while(playerList.Count < 5)
             foreach (var data in playerList)
                 Console.WriteLine(player.Name + ": " + player.Points + " points!");
             return ;
         }*/
        //put platerlist as a public static list outide of teh function så we can ccses it evrywhere and 
        //use playerlist.add({}) instead to add content to the list
    }


    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }

    }
}



