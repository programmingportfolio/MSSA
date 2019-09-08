using System;
using System.Collections.Generic;

namespace TaskList
{
    class Program
    {
        static string userGlobal;
        static string displayTask;
        internal static int currentPosition = -1;

        internal static List<string> tasks = new List<string>();
        internal static List<string> actions = new List<string>();
        internal static List<string> reentries = new List<string>();


        static void Main(string[] args)
        {

            FileManager.LoadTaskList();
            if (currentPosition == -1) { FileManager.FirstTask(); }

            bool quit = false;

            do
            {
                View.DisplayMenu();

                //Console.WriteLine($"\n Current Task: {displayTask}\n");


                try
                {


                    Console.Write("\n Task: ");

                    userGlobal = Console.ReadLine();
                    int userInput = Convert.ToInt32(userGlobal);

                    if (12 > userInput && userInput > 0)
                    {
                        switch (userInput)
                        {
                            case 1:
                                Cleanup.OnView();
                                View.TaskList("first page");
                                Console.WriteLine("\n");
                                break;
                            case 2:
                                Cleanup.OnView();
                                View.TaskList("previous page");
                                Console.WriteLine("\n");
                                break;
                            case 3:
                                Cleanup.OnView();
                                View.TaskList("next page");
                                Console.WriteLine("\n");
                                break;
                            case 4:
                                Actions.Skip();
                                Cleanup.OnView();
                                break;
                            case 5:
                                Program.actions[currentPosition] = Actions.Crossed();
                                Actions.Skip();
                                Cleanup.OnView();
                                break;
                            case 6:
                                Actions.Reenter();
                                Actions.Skip();
                                Cleanup.OnView();
                                break;
                            case 7:
                                Program.actions[Program.currentPosition] = Actions.Complete();
                                Actions.Skip();
                                Cleanup.OnView();
                                break;
                            case 8:
                                Cleanup.OnView();
                                View.Reentries(tasks, reentries);
                                break;
                            case 9:
                                quit = true;
                                break;
                            case 10:
                                Actions.Reset();
                                break;
                            case 11:
                                View.PrintList(Program.tasks, Program.actions, Program.reentries);
                                break;
                        }
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                        Program.displayTask = View.DisplayTask();
                        Console.Write($" Current Task: {displayTask}");
                        Console.BackgroundColor = ConsoleColor.Black;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("\n");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Task Added\n");
                    Program.tasks.Add(userGlobal);
                    Program.actions.Add("none");
                    Program.reentries.Add("0");

                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Program.displayTask = View.DisplayTask();
                    Console.Write($" Current Task: {displayTask}");
                    Console.ResetColor();
                    Console.WriteLine("\n");

                }

            } while (!quit);

            Console.WriteLine("\nExiting Program...\n");
            FileManager.SaveTaskList(tasks, actions, reentries, currentPosition);
            Environment.Exit(0);

        }
    }
}
