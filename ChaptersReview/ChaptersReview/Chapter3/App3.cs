using System;
using System.Collections.Generic;
using System.Text;

namespace ChaptersReview.Chapter3
{
    class App3
    {
        /// <summary>
        /// static is not instance related. Known at compile time.
        /// Cannot change T values to a default type, but can add overloaded methods to handle the overload instead of the T value
        /// Could create a MyMultiply class library, and add reference from class library to ChaptersReview Console Application Project
        /// </summary>

        public void Run()
        {
            int a, b, c, d, e;
            a = b = c = d = e = 7;

            Console.WriteLine(a); //7
            Console.WriteLine(a++); //7
            Console.WriteLine(++a); //9
            Console.WriteLine(a); //9

            Console.WriteLine(e); //7
            Console.WriteLine(e--); //7
            Console.WriteLine(--e); //5
            Console.WriteLine(--e + e++); // 8
            Console.WriteLine(e); //5

            PrintInt(AddThree(7));

            Console.WriteLine(Split(3));
            Console.WriteLine(Split("Cat"));
            Console.WriteLine(TStringPair("Cat"));


            PrintInt('a');






            //tuples, structs usage, and generate methods from values
            var catTuple = CatTuple();

            //Console.WriteLine("Item3 {0}", catTuple.Item3);

            //var (whattheyAre, howMany, averageAge, (minWeight, maxWeight)) = CatTuple();
            //var (whattheyAre, howMany, _, (minWeight, maxWeight)) = CatTuple();

            //Console.WriteLine("Max weight Item 2 of Item 4 = {0}", catTuple.Item4.Item2);
            Console.WriteLine("Max weight Item 2 of WeightRange = {0}", catTuple.WeightRange.Item2);

            //(var minWeight, var maxWeight) = WeightRanges();
            var ( minWeight, maxWeight) = WeightRanges();
            var weightTuple = WeightRanges();

            var ( _, MaxWeight) = WeightRanges();








            //nested method
            //static int Multiply(int v1, int v2 = 1) => v1 * v2;

            Console.WriteLine(MyMultiply.Multiply(v2: 3, v1: 4));
            Console.WriteLine(MyMultiply.Multiply(3));

            //type error because of narrowing, widening works though
            //Console.WriteLine(Multiply(4.2, 7.5));

            Console.WriteLine(MyMultiply.Multiply(1, 2, 3));
        }

        public struct PetData
        {
            public string TypeOfPet;
            public int NumPets;
            public double AverageWeight;
            public (int, int) WeightRange;
        }

        static void PrintInt(int pinkInk)
        {
            if (pinkInk < 0)
                return;
            else
            {
                Console.WriteLine(pinkInk);
            }
        }
        public static int AddThree(int i)
        {
            return i + 3;
        }

        public static (T, T) Split<T>(T i)
        {
            return (i, i);
        }

        public static (T, string) TStringPair<T>(T i)
        {
            return (i, i.ToString());
        }

        //public static (string, int, double, (int, int)) CatTuple()
        //    => ("Cats", 7, 3.4, (6, 11));

        public static PetData CatTuple()
        => new PetData
        {
            TypeOfPet = "Cats",
            NumPets = 7,
            AverageWeight = 3.4,
            WeightRange = WeightRanges()
        };

        private static (int, int) WeightRanges()
        {
            return (6, 11);
        }
    }

    public class MyMultiply
    {
        public static int Multiply(int v1, int v2 = 1) => v1 * v2;
        public static double Multiply(double v1, double v2 = 1) => v1 * v2;
        public static double Multiply(double v1, double v2 = 1, double v3 = 1) => Multiply(v3, Multiply(v1, v2));
    }
}
