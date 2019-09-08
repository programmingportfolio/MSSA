using System;
using System.Collections.Generic;
using System.Text;

namespace TaskList
{
    class Cleanup
    {
        internal static void OnView()
        {
            int length = Program.tasks.Count;


            int i = 0;




            for (; i < length && i < Program.currentPosition; i++)
            {

                if(Program.actions[i] == "none") { return; }
                if (Program.actions[i] == "crossed" || Program.actions[i] == "complete")
                {
                    Program.tasks.RemoveAt(i);
                    Program.actions.RemoveAt(i);
                    Program.reentries.RemoveAt(i);
                    if (Program.currentPosition != 0)
                    {
                        Program.currentPosition--;
                    }
                    else
                    {
                        return;
                    }
                }
            }
        }
    }
}
