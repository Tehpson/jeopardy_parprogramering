using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;

namespace jeopardy_par_programering
{
    class gameLogic
    {
        public static List<Player> players = new List<Player>();
        private static bool wasAnswerRight;
        public static void AddPlayers(List<string> playername) 
        {
            foreach (var player in playername)
            { 
                players.Add(new Player { Name = player, Points = 0 });
            }
        }
        public static void AddScore(string fastestPlayerName, int value, bool wasAnswerRigth)
        {
            if (wasAnswerRight)
            {
                foreach (var player in players)
                {
                    if (player.Name == fastestPlayerName)
                    {
                        player.Points = +value;
                    }
                }
            }
            else
            {
                foreach (var player in players)
                {
                    if (player.Name == fastestPlayerName)
                    {
                        player.Points = -value;
                    }
                }
            }
        }
        //Todo function som kollar vem som vunnit, högst poäng, kopplad till endscreen(stage finns i drawTable)
        public static string TheWinner()
        {
            /*foreach (string entry in splitscores)
            {
                string replace = entry.Replace("[", "").Replace("]", "");
                string[] splitentry = replace.Split('-');

                if (splitentry.Count() > 1)
                {
                    players.Add(new Points(splitentry[0], int.Parse(splitentry[1]));
                }
            }*/
            int topPlayers = players.Max(Name => Name.Points);

            var player = 
            return topPlayers.ToString();
        }
        // humm kan vara bra i slutet där man kollar vem som van. 
        public static int ComparePlayers(Player Name, Player Points) {return 0;}
    }
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}



