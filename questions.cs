using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace jeopardy_par_programering
{
    internal class questions
    {
        /* 
        How to use:
            In the beggning call SetUpData:
                * this will add all date from all the sesons in to a data file that we can call
                * get 6 rendom categories
                * get 5 questions from each catigorie where question 1 is worth 100 and so on
                
            For round two: 
                * Call FilleQuestionList(2)
                * This will first clear all the questions in the List
                * get 5 questions from each catigorie with value 600-1000
         */
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
                        // where there are a tab just split
                        row = tsv[i].Split("\t");

                        // add it in the list 
                        dataList.Add(new data
                        {
                            value = int.Parse(row[1]),
                            category = row[3],
                            answer = row[5],
                            question = row[6],
                            done = false
                        });
                    }
                }

                fillQuestionList();

                sucseed = true;
            }
            catch
            {
                sucseed = false;
            }

            return sucseed;
        }


        public static void fillQuestionList()
        {
            //get 6 rendom catigorys
            question_list.Clear();
            List<string> sixcat = getSixCategories();

            //for each catigory get 5 questions with the correct value and add to List<question_set>
            foreach (string cat in sixcat)
            {
                List<int> questionId = getIdForQuestion(cat);
                question_list.Add(new question_set
                {
                    category = cat,
                    //this will outbout question with value of either round 1 and two so we will have to look if the value is 600 or 100 and so 
                    //an and then if it is +600 den jsut subtract 500 from it 
                    // add Id that we call using question.dataList[question.question_list[0].question1ID].*what you wantoutputed ex answer*
                    // Ex question.dataList[question.question_list[0].question2ID].Value  -- this will output the vlue of the second question in the first cat
                    question1ID = questionId[0],
                    question2ID = questionId[1],
                    question3ID = questionId[2],
                    question4ID = questionId[3],
                    question5ID = questionId[4]
                });
            }


        }


        public static List<string> getSixCategories()
        {
            Random rnd = new Random();
            List<string> sixcat = new List<string>();

            int RendomValue = 0;
            //kollare igneom varje rad av datta vi har och tar kategorin


            // kollar så att vi får 6 katigorer  0 1 2 3 4 5 = 6st
            //för att inte råka få två av samam kategori tar vi simpelt bara
            //bort kategorin från listan av kategorir efter att ha lägt
            //till den i listan med 6 katigorier
            while (sixcat.Count < 6)
            {
                RendomValue = rnd.Next(dataList.Count);
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
                    while (i < sixcat.Count && !excist)
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

                //for debug jsut write out the 6 cat
                /*
                for (int i = 0; i < sixcat.Count; i++)
                {
                    Console.WriteLine(sixcat[i]);
                }*/

            }


            return sixcat;

        }


        public static List<int> getIdForQuestion(string catagory)
        {
            List<int> id = new List<int>();
            Random rnd = new Random();
            List<int> validQuestions = new List<int>();


            Stopwatch stopwatch = new Stopwatch();

            //while we have less then 5 questions 
            while (id.Count < 5)
            {
                int i = 0;
                stopwatch.Start();
                foreach (data data in dataList)
                {
                    //If the time sence started looking thorw data is over 5 seconds and we already have atleast 
                    //one qusetion just continue instead of kep searching like a timeout.
                    if (stopwatch.Elapsed.Seconds > 5 && validQuestions.Count > 1)
                    {
                        break;
                    }

                    if (data.category == catagory && (data.value == ((id.Count + 1) * 100) || data.value == (((id.Count + 1) * 100) + 500)))
                    {
                        // add i where i becmes the id for each row fo data
                        validQuestions.Add(i);
                    }
                    i++;
                }
                stopwatch.Reset();

                id.Add(validQuestions[rnd.Next(validQuestions.Count)]);
                validQuestions.Clear();
            }
            return id;
        }

    }



    //to make a List<List<>> for Data_list
    internal class data
    {
        public int value { get; set; }
        public string category { get; set; }
        public string answer { get; set; }
        public string question { get; set; }
        public bool done { get; set; }
    }

    //to make a List<List<>> for question_list
    internal class question_set
    {
        public string category { get; set; }
        public int question1ID { get; set; }
        public int question2ID { get; set; }
        public int question3ID { get; set; }
        public int question4ID { get; set; }
        public int question5ID { get; set; }
    }

}
