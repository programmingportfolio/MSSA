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
        /// Switch statements are used for passing in a parameter 
        /// and then using its value with boolean comparison
        /// 
        /// </summary>

        /////////////////////////////////////////////////////
        public void Run()
        {
            int x = 1000;
            x = int.Parse(Console.ReadLine());

            Console.WriteLine(x < 10);

            Console.WriteLine(!(7 ==7));
            Console.WriteLine(!(7 != 8));
            Console.WriteLine(10 > 1000);
            Console.WriteLine(10 >= 10);





            /////////////////////////////////////////////////////
            Console.WriteLine("Input number less than 10");
            x = int.Parse(Console.ReadLine());

            //with one line scope
            if (x < 0)
                Console.WriteLine($"Too low...");
            else if(x < 10)
                Console.WriteLine($"Hurray! {x}!");
            else if(x == 10)
                Console.WriteLine($"Man... So close...");
            else
                Console.WriteLine($"Boo! {x} is gross");

            //rewrite with clear scope
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


            /////////////////////////////////////////////////////
            switch (Classify(x))
            {
                case IntClassification.Negative:
                    Console.WriteLine("Too low...");
                    break;
                case IntClassification.InRange:
                    Console.WriteLine($"Hurray! {x}!");
                    break;
                case IntClassification.Close:
                    Console.WriteLine("Man... So close...");
                    break;
                case IntClassification.OutOfRange:
                    Console.WriteLine($"Boo! {x} is gross");
                    break;
                default:
                    throw new InvalidCastException();
            }

        }
        public enum IntClassification { Negative, InRange, Close, OutOfRange}
        public static IntClassification Classify(int i)
        {
            if      (i < 0)   return IntClassification.Negative;
            else if (i < 10)  return IntClassification.InRange;
            else if (i == 10) return IntClassification.Close;
            else              return IntClassification.OutOfRange;
        }
    }
}
