using System;
using System.Collections.Generic;
using System.Text;

namespace ChaptersReview.Chapter2
{
    public class App2
    {
        /// <summary>
        /// Can narrow values like double to int, or widen using int to double.
        /// Order of operators add subtract multiply divide modulus
        /// </summary>

        static void PrintInt(int pinkInk)
        {
            Console.WriteLine(pinkInk);
        }
        public void Run()
        {
            int seven;

            seven = 7;

            //const string eightS = "eight";
            const string eightS = "8";
            //const int eight = 8;
            const double eight = Math.PI * 8F;

            var nine = 9;

            nine = 11;

            int eightFromString = int.Parse(eightS); // will throw error

            double eightAsDouubleFromString = double.Parse(eightS);

            decimal eightAsDecimalFromString = decimal.Parse(eightS);

            PrintInt(8);
            //PrintInt(eight);

            //eight = 12;

            Console.WriteLine(nine.ToString());

            var ls = new List<int>();

            Console.WriteLine(ls.ToString()); // displays type information

            Console.WriteLine((5 + 4) * 5);
            Console.WriteLine(5 + 4 * 5);

            int a, b, c, d, e;

            a = b = c = d = e = 7;

            //instead

            var aa = 7;
            var ab = 7;
            var ac = 7;

        }
    }
}
