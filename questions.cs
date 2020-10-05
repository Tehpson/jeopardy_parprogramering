using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace jeopardy_par_programering
{
    class questions
    {
        public static List<string> readdata(string season)
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
                
            

            path = Path.Combine(projectDirectory, "season"+ seasonNumber + ".tsv");


            List<string> data = new List<string>();
            return data;
        }
    }
}
