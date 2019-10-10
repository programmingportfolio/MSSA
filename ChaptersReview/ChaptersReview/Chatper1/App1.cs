using System;
using System.Collections.Generic;
using System.Text;

namespace ChaptersReview.Chatper1
{
    public static class App1
    {
        /// <summary>
        /// go to debug settings on visual studio and pass in arguments there.
        /// </summary>
  
        public static void Run(string[] args)
        {


            Console.WriteLine(args[3]);

            foreach (var arg in args)
            {
                Console.WriteLine(arg);
            }
        }
    }
}
