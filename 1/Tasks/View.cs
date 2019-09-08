using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    //fix third page issue with next page function, and refer to program
    //break lines
    class View
    {
        static int currentPage = 1;
        static double lengthPages;
        static int currentPosition;

        internal static void DisplayMenu()
        {
            lengthPages = Math.Ceiling(Convert.ToDouble(Program.tasks.Count) / Convert.ToDouble(20));
            Console.WriteLine($" Length of Pages: {lengthPages}\n\n\n\n\n\n\n\n");
            Console.Write("\n 1: TaskList Page 1\n 2: Page -" +
                    "\n 3: Page + \n 4: Skip Task \n 5: Cross-out Task" +
                    "\n 6: Reenter Task \n 7: Complete Task " +
                    "\n 8: View Reentries\n 9: Save & Quit" +
                    "\n 10: 1st Task\n\n\n");

            /*\n 1: TaskList First Page 1\n 2: Previous Page" +
                    "\n 3: Next Page \n 4: Skip Task \n 5: Cross-out Task" +
                    "\n 6: Reenter Task \n 7: Complete Task " +
                    "\n 8: View Reentries\n 9: Save & Quit" +
                    "\n\n\n\n\n\n\n\n\n\n\n"*/
        }
        internal static void TaskList(string control)
        {

            switch (control)
            {
                case "previous page":

                    //**********************************
                    if (currentPage >= lengthPages) { currentPage = Convert.ToInt32(lengthPages); currentPosition = currentPage * 20 - 20; }




                    if (currentPage > 2)
                    {
                        currentPage--;
                        Console.WriteLine($"\n\n Page: {currentPage}");
                        int deinc = currentPosition;
                        int temp = deinc;
                        for (; deinc > temp - 20; deinc--)
                        {
                            if (deinc % 20 == 0)
                            {
                                Console.Write(" |");
                            }

                            bool complete = false;
                            bool crossed = false;
                            bool marker = false;

                            if (deinc == Program.currentPosition)
                            {
                                marker = true;

                                if (Program.actions[deinc] == "crossed")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }


                                Console.Write($"{Program.tasks[deinc]}");
                                Console.ResetColor();
                                Console.WriteLine("|");

                            }
                            else
                            {

                                if (Program.actions[deinc] == "complete")
                                {
                                    complete = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (Program.actions[deinc] == "crossed")
                                {
                                    crossed = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }




                                Console.Write($"{Program.tasks[deinc]}");


                                if (crossed == true || complete == true || marker == true)
                                {
                                    Console.ResetColor();
                                }
                                Console.Write("|");
                            }
                        }
                        currentPosition = deinc;
                    }
                    else
                    {
                        TaskList("first page");
                    }
                    break;







                case "first page":

                    currentPage = 1;
                    Console.WriteLine($"\n\n Page: {currentPage}");
                    currentPosition = 0;
                    int i = currentPosition;












                    if (Program.tasks.Count < 20)
                    {
                        for (; i < Program.tasks.Count; i++)
                        {
                            if (i % 20 == 0)
                            {
                                Console.Write(" |");
                            }

                            bool complete = false;
                            bool crossed = false;
                            bool marker = false;

                            if (i == Program.currentPosition)
                            {
                                marker = true;

                                if (Program.actions[i] == "crossed")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }


                                Console.Write($"{Program.tasks[i]}");
                                Console.ResetColor();
                                Console.Write("|");

                            }
                            else
                            {

                                if (Program.actions[i] == "complete")
                                {
                                    complete = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (Program.actions[i] == "crossed")
                                {
                                    crossed = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }




                                Console.Write($"{Program.tasks[i]}");


                                if (crossed == true || complete == true || marker == true)
                                {
                                    Console.ResetColor();
                                }
                                Console.Write("|");
                            }


                        }
                    }











                    else
                    {
                        for (; i < 20; i++)
                        {
                            if (i % 20 == 0)
                            {
                                Console.Write(" |");
                            }

                            bool complete = false;
                            bool crossed = false;
                            bool marker = false;

                            if (i == Program.currentPosition)
                            {
                                marker = true;

                                if (Program.actions[i] == "crossed")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }


                                Console.Write($"{Program.tasks[i]}");
                                Console.ResetColor();
                                Console.Write("|");

                            }
                            else
                            {

                                if (Program.actions[i] == "complete")
                                {
                                    complete = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (Program.actions[i] == "crossed")
                                {
                                    crossed = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }




                                Console.Write($"{Program.tasks[i]}");


                                if (crossed == true || complete == true || marker == true)
                                {
                                    Console.ResetColor();
                                }
                                Console.Write("|");
                            }
                        }
                    }
                    currentPosition = i;
                    return;





                case "next page":



                    if (lengthPages == 1) { TaskList("first page"); return ; }



                    currentPage++;

                    //***************************************
                    if (currentPage >= lengthPages) { currentPage = Convert.ToInt32(lengthPages); currentPosition = currentPage * 20 - 20; }
                    Console.WriteLine($"\n\n Page: {currentPage}");
                    int inc = currentPosition;






                    //***********************************
                    if (lengthPages == currentPage)
                    {
                        for (; inc < Program.tasks.Count; inc++)
                        {
                            if (inc % 20 == 0)
                            {
                                Console.Write(" |");
                            }

                            bool complete = false;
                            bool crossed = false;
                            bool marker = false;

                            if (inc == Program.currentPosition)
                            {
                                marker = true;

                                if (Program.actions[inc] == "crossed")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }


                                Console.Write($"{Program.tasks[inc]}");
                                Console.ResetColor();
                                Console.Write("|");

                            }
                            else
                            {

                                if (Program.actions[inc] == "complete")
                                {
                                    complete = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (Program.actions[inc] == "crossed")
                                {
                                    crossed = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }




                                Console.Write($"{Program.tasks[inc]}");


                                if (crossed == true || complete == true || marker == true)
                                {
                                    Console.ResetColor();
                                }
                                Console.Write("|");
                            }

                        }
                    }









                    else
                    {
                        int temp = inc;
                        for (; inc < temp + 20; inc++)
                        {
                            if (inc % 20 == 0)
                            {
                                Console.Write(" |");
                            }

                            bool complete = false;
                            bool crossed = false;
                            bool marker = false;

                            if (inc == Program.currentPosition)
                            {
                                marker = true;

                                if (Program.actions[inc] == "crossed")
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.Red;
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Black;
                                    Console.BackgroundColor = ConsoleColor.White;
                                }


                                Console.Write($"{Program.tasks[inc]}");
                                Console.ResetColor();
                                Console.Write("|");

                            }
                            else
                            {

                                if (Program.actions[inc] == "complete")
                                {
                                    complete = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }
                                if (Program.actions[inc] == "crossed")
                                {
                                    crossed = true;
                                    Console.ForegroundColor = ConsoleColor.DarkGray;
                                }




                                Console.Write($"{Program.tasks[inc]}");


                                if (crossed == true || complete == true || marker == true)
                                {
                                    Console.ResetColor();
                                }
                                Console.Write("|");
                            }
                        }
                    }
                    currentPosition = inc;
                    break;
            }




        }

        internal static void Reentries(List<string> tasks, List<string> reentries)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"Task: {tasks} Reentries: {reentries}");
            }

        }

        internal static string DisplayTask()
        {
            return Program.tasks[Program.currentPosition];


        }


        //Developer use only
        internal static void PrintList(List<string> tasks, List<string> actions, List<string> reentries)
        {
            for (int i = 0; i < tasks.Count; i++)
            {
                Console.WriteLine($"Task: {tasks[i]} Action: {actions[i]} Reentries: {reentries[i]}");
            }
        }
    }
}
