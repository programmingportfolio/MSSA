using System;
using System.Collections.Generic;
using System.Text;

namespace ChaptersReview.Chapter4
{
    public class App4
    {
        /// <summary>
        /// x | y | x && y | !((!finished) && y && x)
        /// --------------
        /// F |  T  |  F
        /// F |  F  |  F
        /// T |  T  |  T
        /// T |  F  |  F
        /// 
        /// </summary>

        public void Run()
        {
            int x = 1000;
            x = int.Parse(Console.ReadLine());

            Console.WriteLine(x < 10);

            Console.WriteLine(!(7 ==7));
            Console.WriteLine(!(7 != 8));
            Console.WriteLine(10 > 1000);
            Console.WriteLine(10 >= 10);






            Console.WriteLine("Input number less than 10");
            x = int.Parse(Console.ReadLine());
            if (x < 0)
                Console.WriteLine($"Too low...");
            else if(x < 10)
                Console.WriteLine($"Hurray! {x}!");
            else if(x == 10)
                Console.WriteLine($"Man... So close...");
            else
                Console.WriteLine($"Boo! {x} is gross");

            if (x < 0)
            {
                Console.WriteLine($"Too low...");
            }
            else if (x < 10)
            {
                Console.WriteLine($"Hurray! {x}!");
            }
            else if (x == 10)
            {
                Console.WriteLine($"Man... So close...");
            }
            else
            {
                Console.WriteLine($"Boo! {x} is gross");
            }
        }
    }
}
