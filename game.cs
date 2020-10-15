using System;
using System.Collections.Generic;
using System.Text;

namespace jeopardy_par_programering
{
    class game
    {


        //        //here do we but all the functions that make the game work like caclutating scores and so on.

        /*      TODO:
         *      make score funtioction
         *      make a function that enters all the users (thinking that ppl can enter players name in the beggingin) kinda like List<data>
         *      ...
         */

        //Börjat jobba med score function,
        string[,] categories_points = new string[5, 5]
        {
            {" $100  ", "  $100  ", "  $100  ", "  $100  ", "  $100  " },
            {" $200  ", "  $200  ", "  $200  ", "  $200  ", "  $200  " },
            {" $300  ", "  $300  ", "  $300  ", "  $300  ", "  $300  " },
            {" $400  ", "  $400  ", "  $400  ", "  $400  ", "  $400  " },
            {" $500  ", "  $500  ", "  $500  ", "  $500  ", "  $500  " }
        };
        string[] categories = new string[] { };//get categories from tsv file
        int category = 0;

        public static List<string> PlayerName(string name)
        {
            // List<string> PlayerList = new List<string>();
            //PlayerList.AddRange(name);
            //return PlayerList;//hur ger man bäst ett return value på detta?
            
            var listName = new List<string>();
            
            string playerName = "Philip";

            listName.Add(playerName);

            foreach (var item in listName)
            {
                Console.WriteLine(item);
            }

            return listName;
        }
        //Tänker en function som man kan kalla på för att se och jämföra poängen mellan de tävlande
        //Typ som detta?
        public static int ComparePlayers(Player Name)

        
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



