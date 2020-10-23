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
        public static void AddPlayers(List<string> playername) 
        {
            foreach (var player in playername)
            { 
                players.Add(new Player { Name = player, Points = 0 });
            }
        }
        public static void AddScore(string fastestPlayerName, int value, bool wasAnswerRigth)
        {
            if (wasAnswerRigth)
            {
                foreach (var player in players)
                {
                    if (player.Name == fastestPlayerName)
                    {
                        player.Points += value;
                    }
                }
            }
            else
            {
                foreach (var player in players)
                {
                    if (player.Name == fastestPlayerName)
                    {
                        player.Points -= value;
                    }
                }
            }
        }
        //Todo function som kollar vem som vunnit, högst poäng, kopplad till endscreen(stage finns i drawTable)
        public static List<Player> TheWinner()
        {
            List<Player> winner = new List<Player>();
            int highestScore = players.Max(Name => Name.Points);
            foreach (var item in players)
            {
                if (item.Points == highestScore)
                {
                    winner.Add(new Player { Name = item.Name, Points = item.Points });
                }
            }

            return winner;
        }
        // humm kan vara bra i slutet där man kollar vem som van. 
        public static List<Player> ComparePlayers()
        {
            List<Player> SortedList = players.OrderByDescending(o => o.Points).ToList();

            return SortedList;
        }
    }
    public class Player
    {
        public string Name { get; set; }
        public int Points { get; set; }
    }
}



