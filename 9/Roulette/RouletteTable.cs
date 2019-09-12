using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    struct RouletteTable
    {
        public static int[] Numbers { get; set; }
        public static string[,] ColorAndName { get; set; }

        public RouletteTable(int[] numbers, string[,] colorAndName)
        {
            Numbers = numbers;
            ColorAndName = colorAndName;

        }

        public static string PrintName(int number)
        {
            var build = "";
            for(int i = 0; i < 2; i++)
            {
                build += $" {ColorAndName[number, i]}";
            }

            return build;
        }
    }
}
