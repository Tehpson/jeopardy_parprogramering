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
        public static List<data> filedata = new List<data>();
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
                sucseed = true;
            }
            catch
            {
                Console.WriteLine("looks like we don't have the seasong you choos from");
                sucseed = false;
            }

            return sucseed;

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
