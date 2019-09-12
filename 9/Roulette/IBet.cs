using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    public interface IBet
    {
        public decimal UserLoop(Random random, decimal money);
        decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0);
        decimal OnWin(decimal money, int option);
        decimal OnLose(decimal money);

    }
}
