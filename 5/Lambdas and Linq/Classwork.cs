using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lambdas_and_Linq
{
    struct Classwork
    {
        public void Run()
        {

            Func<string> HelloW = () => "Hello, World";
            Console.WriteLine($"1: HelloW() = {HelloW()}");

            Func<int, int> intIncr = x => x + 1;

            Console.WriteLine($"2: intIncr(2) = {intIncr(2)}");

            Func<int, int, int> intPower = (x, y) => (int)Math.Pow((double)y, (double)x);

            Console.WriteLine($"3: intPower(2, 2) = {intPower(2, 2)}");

            Func<int, int, int> intSum = (x, y) => x + y;

            Console.WriteLine($"4: intSum(1, 1) = {intSum(1, 1)}");

            Func<string, string, string> stringBuild = (x, y) => x + y;

            Console.WriteLine($"5: stringBuild(string, Build) = {stringBuild("string", "Build")}");






            IEnumerable<int> oneTen = Enumerable.Range(1, 10);

            var stringNum = new List<string>() { "one", "two", "three", "four" };


            var newInc = oneTen.Select(intIncr);
            Console.WriteLine("1: newInc");
            foreach (int i in newInc)
            {
                Console.WriteLine(i);
            }


            //var newAdds = oneTen.Aggregate((x, y) => Math.Pow(x, y));
            var newAdds = oneTen.Aggregate(intSum);

            Console.WriteLine($"2: newAdds = {newAdds}");


            var newPowers = oneTen.Select(x => intPower(x, 2));

            Console.WriteLine("3: Print oneTen list");

            foreach (int i in newPowers)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();


            //var stringCon = stringNum.Aggregate("", (x, y) => x + "" + y);

            string stringCon = "";
            stringCon += stringNum.Aggregate("", (x, y) => stringBuild(x, y));


            Console.WriteLine($"4: stringCon = {stringCon}");

            double arb = 0;
            arb += Tetration(2, 4, 2);

            Console.WriteLine(arb);

            var arb2 = Enumerable.Repeat(2, 4);

            var tetration = arb2.Aggregate(intPower);

            Console.WriteLine($"5: Tetration = {tetration}");
        }
        static double Tetration(double x, double y, double n = 2)
        {
            if (n == 1)
            {
                return Math.Pow(x, y);
            }
            else if (n >= 1 && y == 0)
            {
                return 1;
            }
            else
            {
                return Tetration(x, Tetration(x, (y - 1), n), n - 1);
            }
        }
    }
}

