using System;
using System.Collections.Generic;
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

        //Börjat jobba med score function,
        //idk tror inte vi beöhver detta då jag sickar till dig spelare och value och ifall det var rätt eller fel.  gör istället en void function som tar in stirng Name, int Value, bool answer
        /*string[,] categories_points = new string[5, 5]
        {
            {" $100  ", "  $100  ", "  $100  ", "  $100  ", "  $100  " },
            {" $200  ", "  $200  ", "  $200  ", "  $200  ", "  $200  " },
            {" $300  ", "  $300  ", "  $300  ", "  $300  ", "  $300  " },
            {" $400  ", "  $400  ", "  $400  ", "  $400  ", "  $400  " },
            {" $500  ", "  $500  ", "  $500  ", "  $500  ", "  $500  " }
        };
        string[] categories = new string[] { };//get categories from tsv file
        int category = 0;*/


        // här gör att du ahr imot en lista med namn istället, och sedan för List.count loppar du till du har laggt in alla 
        //gör ändast void functioner då ci inte kommer behlva få tillbaka någon data när vi kllar på dem. (public static void addPlayers(List<string> playername))
        public static void addPlayers(List<string> playername)
        {
            foreach (var player in playername)
            {
                playername.Add({ name = player, points = 500});
            }
        }

        // List<string> PlayerList = new List<string>();
        //PlayerList.AddRange(name);
        //return PlayerList;//hur ger man bäst ett return value på detta?
        /*
        var listName = new List<string>();

        string playerName = "Philip";

        listName.Add(playerName);

        foreach (var item in listName)
        {
            Console.WriteLine(item);
        }


    }*/
        //Tänker en function som man kan kalla på för att se och jämföra poängen mellan de tävlande
        //Typ som detta?
        // humm kan vara bra i slutet där man kollar vem som van. 
        public static int ComparePlayers(Player Name) { return 0; }

        
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



