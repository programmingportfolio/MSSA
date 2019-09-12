using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    abstract class Print
    {
        public static void Array<T>(T[] array)
        {
            Console.WriteLine("\nNumber Array Printout");
            foreach (T item in array)
            {
                
                Console.Write($" {item} ");
            }
        }
        public static void Array<T>(T[,] array)
        {
            Console.WriteLine("\nColor and Name Printout");
            foreach (T item in array)
            {
                
                Console.Write($" {item} ");
            }
        }
    }
}
