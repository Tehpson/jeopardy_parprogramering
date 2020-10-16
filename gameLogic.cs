using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace jeopardy_par_programering
{
    class gameLogic
    {
        public static List<Player> players = new List<Player>();


        /*      TODO:
         *      Function that add teh players to a playerlist
         *      Funtion that add or subtract score from the player
         */
        //idk tror inte vi beöhver detta då jag sickar till dig spelare och value och ifall det var rätt eller fel.  gör istället en void function som tar in stirng Name, int Value, bool answer

        // här gör att du ahr imot en lista med namn istället, och sedan för List.count loppar du till du har laggt in alla 
        //gör ändast void functioner då ci inte kommer behlva få tillbaka någon data när vi kllar på dem.

        public static void ScoreCalculator()
        {
            /*points = int.TryParse();
            ScoreCalculator.Add(points)
            for (int i = 0; i<score.Count; i++)
            {
                totalScore += score[i];
            }*/
            int[] pointTable = new int[5] { 100, 200, 300, 400, 500 };
        }
        
    public static void AddPlayers(List<string> playername)
        public static void AddPlayers(List<string> playername)
        {
            foreach (var player in playername)
            {
                //sorry var jag som fukcade upp 
                players.Add(new Player { Name = player, Points = 0 });
            }
        }
        // humm kan vara bra i slutet där man kollar vem som van. 
        public static int ComparePlayers(Player Name) { return 0; }

        //bara added denna du löser vad den gör
        internal static void addScore(string fastestPlayerName, int value, bool wasAnswerRigth)
        {
            
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



