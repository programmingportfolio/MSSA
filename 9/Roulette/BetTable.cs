using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    struct BetTable
    {
        public static int[] NumbersArray1 { get; set; }
        public static int[] NumbersArray2 { get; set; }
        public static int[] NumbersArray3 { get; set; }

        public BetTable(int[] numbersArray1, int[] numbersArray2, int[] numbersArray3)
        {
            NumbersArray1 = numbersArray1;
            NumbersArray2 = numbersArray2;
            NumbersArray3 = numbersArray3;
        }
    }
}
