using System;
using System.Collections.Generic;
using System.Text;

namespace jeopardy_par_programering
{
    class game
    {
        //here do we but all the functions that make the game work like caclutating scores and so on.

        /*      TODO:
         *      make score funtioction
         *      make a function that enters all the users (thinking that ppl can enter players name in the beggingin) kinda like List<data>
         *      ...
         */
        public static void PlayerList()
        {
            List<Player> playerList = new List<Player>()
            {
                new Player() {Name = "Philip", Points = 500}
            };
            playerList.Sort(ComparePlayers);
            foreach (player player in playerList)
            Console.WriteLine(player.Name + ": " + player.Points + " points!");
        }
        public static int ComparePlayers(Player player1, Player player2, Player player3)
        {
            return player1.Points.CompareTo(player2.Points, player3.Points);
        }

        public class Player
        {
            public string Name { get; set; }
            public int Points { get; set; }
        }


        playerList.add(new player{name = "Jesper", Points = 1000});
    }
}





