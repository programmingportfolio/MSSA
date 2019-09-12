using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    abstract class Payouts
    {

        public static decimal OneToOne(decimal money) => money * 1;
        public static decimal TwoToOne(decimal money) => money * 2;
        public static decimal FiveToOne(decimal money) => money * 5;
        public static decimal SixToOne(decimal money) => money * 6;
        public static decimal EightToOne(decimal money) => money * 8;
        public static decimal ElevenToOne(decimal money) => money * 11;
        public static decimal SeventeenToOne(decimal money) => money * 17;
        public static decimal ThirtyFiveToOne(decimal money) => money * 35;
    }
}
