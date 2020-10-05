using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text;

namespace jeopardy_par_programering
{
    class questions
    {
        public static void setupData(string season)
        {
            string workingDirectory, projectDirectory, path;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            path = Path.Combine(projectDirectory, "jeopardy_clue_dataset");


            string seasonB = string.Empty;
            int seasonNumber = 1;
            for (int i = 0; i < season.Length; i++)
            {
                if (Char.IsDigit(season[i]))
                    seasonB += season[i];
            }

            if (seasonB.Length > 0)
                seasonNumber = int.Parse(seasonB);

            path = Path.Combine(projectDirectory, "jeopardy_clue_dataset");
            path = Path.Combine(path, "season"+ seasonNumber + ".tsv");

            string[] file = File.ReadAllLines(path);
            List<data> filedata = new List<data>();
            string[] row;

            for (int i = 0; i < file.Length; i++)
            {
                row = file[i].Split("\n");
                filedata.Add(new data
                {
                    value = row[1],
                    daily_double = row[2],
                    category = row[3],
                    answer = row[5],
                    question = row[6]
                });
            }


        }
        private class data
        {
            public string value { get; set; }
            public string daily_double { get; set; }
            public string category { get; set; }
            public string answer { get; set; }
            public string question { get; set; }
        }

    }
}
