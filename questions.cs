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


        public static List<data> dataList = new List<data>();
        public static List<question_set> question_list = new List<question_set>();
        public static bool setUpData()
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

                //get 6 rendom catigorys
                List<string> sixcat = getSixCategories();

                //for each catigory get 5 questions with the correct value and add to List<question_set>
                foreach (string cat in sixcat)
                {
                    List<int> questionId = getIdForQuestion(cat, 1);
                    question_list.Add(new question_set
                    {
                        category = cat,
                        question1 = dataList[questionId[0]].question,
                        question2 = dataList[questionId[1]].question,
                        question3 = dataList[questionId[2]].question,
                        question4 = dataList[questionId[3]].question,
                        question5 = dataList[questionId[4]].question
                    });
                }

                sucseed = true;
            }
            catch
            {
                sucseed = false;
            }

            return sucseed;
        }
            

        public static List<string> getSixCategories()
        {
            Random rnd = new Random();
            List<string> sixcat = new List<string>();


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


            return sixcat;
            //for debug jsut write out the 6 cat
            /*
            for (int i = 0; i < sixcat.Count; i++)
            {
                Console.WriteLine(sixcat[i]);
            }*/
        }


        public static List<int> getIdForQuestion(string catagory, int round)
        {
            List<int> id = new List<int>();
            Random rnd = new Random();
            List<int> validQuestions = new List<int>();

            
            if (round == 1)
            {
                while(id.Count < 4)
                for (int i = 0; i < dataList.Count; i++)
                {
                    if (dataList[i].category == catagory && dataList[i].value == ((id.Count + 1) * 100).ToString())
                    {
                        validQuestions.Add(i);
                    }
                }
                id.Add(validQuestions[rnd.Next(validQuestions.Count)]);
            }

            if (round == 2)
            {
                while (id.Count < 4)
                    for (int i = 0; i < dataList.Count; i++)
                    {
                        if (dataList[i].category == catagory && dataList[i].value == ((id.Count + 1) * 200).ToString())
                        {
                            validQuestions.Add(i);
                        }
                    }
                id.Add(validQuestions[rnd.Next(validQuestions.Count)]);
            }

            return id;
        }

    }



    //to make a List<List<>> for Data_list
    class data
    {
        public string value { get; set; }
        public string daily_double { get; set; }
        public string category { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
    }

    //to make a List<List<>> for question_list
    class question_set
    {
        public string category { get; set; }
        public string question1 { get; set; }
        public string question2 { get; set; }
        public string question3 { get; set; }
        public string question4 { get; set; }
        public string question5 { get; set; }
    }

}
