using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    abstract class Actions
    {

        Actions()
        {
        }

        // future make crossed be something you revisit and verify and complete.
        internal static string Complete()
        {
            Console.WriteLine(" Completing Task...");
            return "complete";
        }
        internal static string Crossed()
        {
            Console.WriteLine(" Crossing Task...");
            return "crossed";
        }

        internal static void Skip()
        {
            int i = Program.currentPosition;
            Console.WriteLine(" Skipping Task...");




            try
            {
                if (Program.currentPosition != Program.tasks.Count - 1)
                {
                    for (; i < Program.actions.Count - 1; i++)
                    {
                        if (Program.actions[i + 1] != "complete")
                        {
                            Program.currentPosition = i + 1;
                            return;
                        }
                        else
                        {
                            continue;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Nothing to skip");
                    return;
                }
            }
            
            catch (Exception)
            {
                FileManager.FirstTask();
                return;
            }
           

            
                
            
        }




        internal static void Reenter()
        {
            Console.WriteLine(" Reentering Task...");
            Program.actions[Program.currentPosition] = Crossed();
            MoveToEnd();

        }

        internal static void Reset()
        {
            Cleanup.OnView();
            int i = 0;
            for (; i >= 0; i++)
            {
                if(Program.actions[i] == "complete") { continue; }
                if (Program.actions[i] == "none" || Program.actions[i] == "crossed")
                {
                    Program.currentPosition = i;
                    return;
                }
            }
        }

        static void MoveToEnd()
        {
            Program.tasks.Add(Program.tasks[Program.currentPosition]);
            Program.actions.Add("none");
            int reentry = Convert.ToInt32(Program.reentries[Program.currentPosition]);
            reentry += 1;
            Program.reentries.Add(reentry.ToString());
        }

    }
}
