using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;

namespace TaskList
{
    abstract class FileManager
    {
        static string filename = "TaskList.txt";

        internal static void DeleteFile()
        {
            File.Delete(filename);
        }


        internal static void LoadTaskList()
        {

            try
            {
                string fileContents = File.ReadAllText(filename);

                if (fileContents == "") { return; }

                Console.WriteLine(" Loading previous files...\n");

                string task;

                string[] stringArray = Regex.Split(fileContents, ", ");

               
                int number;
                int i = 0;
                for (; i < stringArray.Length;)
                {

                    task = stringArray[i];

                    if (i == stringArray.Length - 1)
                    {
                        number = Convert.ToInt32(task);
                        Program.currentPosition = number;

                    }
                    else
                    {
                        string action = stringArray[i + 1];
                        string reentries = stringArray[i + 2];
                        Program.tasks.Add(task);
                        Program.actions.Add(action);
                        Program.reentries.Add(reentries);
                    }
                    //if (Int32.TryParse(task, out number) == true)
                    //{
                    //    Program.currentPosition = Convert.ToInt32(task);
                    //    Console.WriteLine(task);
                    //    return;
                    //}

                    i += 3;



                    

                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Exception thrown");
                return;
            }
            Cleanup.OnView();
            Program.currentPosition = 0;

        }

        internal static void SaveTaskList(List<string> tasks, List<string> actions, List<string> reentries, int mainPosition)
        {
            if (filename == null) { File.Create(filename); }
            StringBuilder fileOutput = new StringBuilder();
            int i = 0;
            for (; i < tasks.Count; i++)
            {
                fileOutput.Append($"{tasks[i]}, {actions[i]}, {reentries[i]}, ");
            }

            fileOutput.Append($"{mainPosition}");
            Console.WriteLine("Saving TaskList...");
            using (StreamWriter sw = new StreamWriter(filename))
            {
                sw.Write(fileOutput.ToString());
            }
        }


        internal static void FirstTask()
        {
            FileManager.DeleteFile();




            Console.Write("\n Enter Task: ");
            string firstInput = Console.ReadLine();
            Console.Write("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
            Program.tasks.Add(firstInput);
            Program.actions.Add("none");
            Program.reentries.Add("0");
            Program.currentPosition = 0;

            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.ForegroundColor = ConsoleColor.Black;
                string displayTask;
                displayTask = View.DisplayTask();
                Console.Write($" Current Task: {displayTask}");
                Console.ResetColor();
                Console.WriteLine("\n");
            }
        }
    }
}

