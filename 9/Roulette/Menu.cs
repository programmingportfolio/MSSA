using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    abstract class Menu
    {
        public static void ClearForFeedback()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        public static void ClearCompletely()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n\n");
        }

        public static void UserFeedback(string message)
        {
            Console.WriteLine($"\n {message}");
        }
        public static void AfterInput()
        {
            Console.WriteLine("");
        }
    }
}
