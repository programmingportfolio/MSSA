using System;
using System.Collections.Generic;
using System.Text;

namespace BisectionAlgorithm
{
    public class Test
    {
        static List<int> temp2;
        public static string Index(Random random, int start)
        {
            var answer = random.Next(1, 11);
            var list = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                list.Add(i);
            }

            List<int> temp = list.GetRange(0, start + 1);
            string build = "";
            foreach(int i in temp)
            {
                build += i.ToString();
            }
            Console.WriteLine(build);
            return build;

        }
        public static string Index2(Random random, int start)
        {
            var answer = random.Next(1, 11);
            var list = new List<int>();
            for (int i = 0; i < 11; i++)
            {
                list.Add(i);
            }
            if (list.Count - 1 == start)
            {
                List<int> temp = list.GetRange(start, list.Count - start);
                Test.temp2 = temp;
            }
            else
            {
                List<int> temp = list.GetRange(start, list.Count - start);
                Test.temp2 = temp;
            }

            string build = "";
            foreach (int i in Test.temp2)
            {
                build += i.ToString();
            }

            return build;

        }
    }
}