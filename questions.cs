using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace jeopardy_par_programering
{
    class questions
    {

        /*  TO DO:
         *  make rendom function
         *  make get all where category is / take one of each value where cetegory is
         *  store all active filedata/queston to make it easier to get the answer and give out points ang not care about inrelvant "qustions"
         
        */


        public static List<data> filedata = new List<data>();
        public static List<string> sixcat = new List<string>();
        public static bool setupData(string season)
        {
            
            bool sucseed;
            //get the path to the rigth diractery
            string workingDirectory, projectDirectory, path;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            path = Path.Combine(projectDirectory, "jeopardy_clue_dataset");

            //--------takes jsut hte numbers in teh string that was inserted by player
            string seasonB = string.Empty;
            int seasonNumber = -1; // -1 makes so if no numbers was enterd the program would just go to catch in later stages
            for (int i = 0; i < season.Length; i++)
            {
                if (Char.IsDigit(season[i]))
                    seasonB += season[i];
            }

            if (seasonB.Length > 0)
                seasonNumber = int.Parse(seasonB);
            //-------------------------


            //this is under try jsut to see if this work else the player have enterd an invalid season and have to redo it.
            try
            {
                path = Path.Combine(projectDirectory, "jeopardy_clue_dataset");
                path = Path.Combine(path, "season"+ seasonNumber + ".tsv");

                string[] file = File.ReadAllLines(path);
                
                string[] row;

                for (int i = 1; i < file.Length; i++)
                {
                    row = file[i].Split("\t");
                    filedata.Add(new data
                    {
                        value = row[1],
                        daily_double = row[2],
                        category = row[3],
                        answer = row[5],
                        question = row[6]
                    });
                }

                //skulel kuna läga in hela funtionen här då vi bara kallar 
                //på den en gång men vet inte hur runda två fungerar ifall 
                //man ska ha 6st nya kateogirer därfölr jag gjorde en funktion för det
                getSixCategories();
                sucseed = true;
            }
            catch
            {
                Console.WriteLine("looks like we don't have the seasong you choose from");
                sucseed = false;
            }
            
            return sucseed;

        }

        public static void getSixCategories()
        {
            Random rnd = new Random();

            List<string> categories = new List<string>();
            
            //kollare igneom varje rad av datta vi har och tar kategorin
            for (int i = 0; i < filedata.Count; i++)
            {
                string outcat = filedata[i].category;
                //ifall vi itne har någon categori i våran lista av kategorier 
                //så lägger vi till annars kolla vilka kalteogrier vi har
                if (categories.Count == 0) 
                {
                    categories.Add(outcat);
                }
                else
                {
                    bool numCatExist = false;
                    //kollar för varej katogori vi har ifall den stämmer överäns med den som fildata gav till oss.
                    for (int y = 0; y < categories.Count; y++)
                    {
                        //ifall catekorin finns en ända gång säger vi att den finns
                        if (categories[y].ToString() == outcat.ToString())
                        {
                            numCatExist = true;
                        }
                    }
                    //ifall kategorin inte fanns lägger vi till den ananrs så går vi bara vidare
                    if (!numCatExist)
                    {
                        categories.Add(outcat);
                    }
                }
            }

            // kollar så att vi får 6 katigorer  0 1 2 3 4 5 = 6st
            //för att inte råka få två av samam kategori tar vi simpelt bara
            //bort kategorin från listan av kategorir efter att ha lägt
            //till den i listan med 6 katigorier
            while (sixcat.Count < 5)
            {
                int RendomValue = rnd.Next(categories.Count);
                sixcat.Add(categories[RendomValue]);
                categories.RemoveAt(RendomValue);
            }

            for (int i = 0; i < sixcat.Count; i++)
            {
                Console.WriteLine(sixcat[i]);
            }
        }

        //need to be public so filedata can be public. this feels stupid but cant find a another way.
        public class data
        {
            public string value { get; set; }
            public string daily_double { get; set; }
            public string category { get; set; }
            public string answer { get; set; }
            public string question { get; set; }
        }

    }
}
