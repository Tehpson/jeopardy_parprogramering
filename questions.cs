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
         *  store all active dataList/queston to make it easier to get the answer and give out points ang not care about inrelvant "qustions"
         
        */


        public static List<data> dataList = new List<data>();
        public static List<string> sixcat = new List<string>();
        public static bool setupData()
        {
            
            bool sucseed;

            //get the path to the rigth diractery
            string workingDirectory, projectDirectory, path;
            workingDirectory = Environment.CurrentDirectory;
            projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            path = Path.Combine(projectDirectory, "jeopardy_clue_dataset");
            DirectoryInfo directoryInfo = new DirectoryInfo(path);

            
            try
            {
                //for each file in teh diractoy that ends in TSV get the data and add it to the dataList.
                foreach (FileInfo file in directoryInfo.GetFiles("*.tsv"))
                {
                    string[] tsv = File.ReadAllLines(file.FullName);

                    string[] row;

                    for (int i = 1; i < tsv.Length; i++)
                    {
                        row = tsv[i].Split("\t");
                        dataList.Add(new data
                        {
                            value = row[1],
                            daily_double = row[2],
                            category = row[3],
                            answer = row[5],
                            question = row[6]
                        });
                    }
                }


                getSixCategories();
                sucseed = true;
            }
            catch
            {
                sucseed = false;
            }

            return sucseed;
        }
            

        public static void getSixCategories()
        {
            Random rnd = new Random();

           
            
            //kollare igneom varje rad av datta vi har och tar kategorin
         

            // kollar så att vi får 6 katigorer  0 1 2 3 4 5 = 6st
            //för att inte råka få två av samam kategori tar vi simpelt bara
            //bort kategorin från listan av kategorir efter att ha lägt
            //till den i listan med 6 katigorier
            while (sixcat.Count < 5)
            {
                int RendomValue = rnd.Next(dataList.Count);
                //if there is no katigoris already then just add it else se if teh rendom cat already exist
                if (sixcat.Count == 0)
                {
                    sixcat.Add(dataList[RendomValue].category);
                }
                else
                {
                    bool excist = false;
                    int i = 0;
                    //while category don't extist and we haven't lookd at all categry in out 6 once if it colide cheack else go past
                    while(i < sixcat.Count && !excist)
                    {
                        if (sixcat[i] == dataList[RendomValue].category)
                        {
                            excist = true;
                        }
                        i++;
                    }
                    if (!excist)
                    {
                        sixcat.Add(dataList[RendomValue].category);
                    }
                    
                }
                
            }


            //for debug jsut write out the 6 cat
            /*
            for (int i = 0; i < sixcat.Count; i++)
            {
                Console.WriteLine(sixcat[i]);
            }*/
        }

    }



    //just use this to get a list with this valus in it
    class data
    {
        public string value { get; set; }
        public string daily_double { get; set; }
        public string category { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
    }

}
