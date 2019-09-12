using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette.PlaceBet
{
    struct TwelveNum : IBet
    {

        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var generate = random.Next(1, 37);
            Console.WriteLine($"Result: {RouletteTable.PrintName(generate)}");
            if (Enumerable.Range(1, 12).Contains(generate) && one == 1)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(12, 24).Contains(generate) && one == 2)
            {
                return OnWin(money);
            }
            if(Enumerable.Range(24,37).Contains(generate) && one == 3)
            {
                return OnWin(money);
            }
            else
            {
                return OnLose(money);
            }
        }

        public decimal OnLose(decimal money)
        {
            Console.WriteLine("You Lost.");
            var diff = -(money);
            return diff;
        }

        public decimal OnWin(decimal money, int option = 0)
        {
            Console.WriteLine("You won!");
            var diff = Payouts.TwoToOne(money) - money;
            return diff;
        }

        public decimal UserLoop(Random random, decimal money)
        {
            Menu.ClearCompletely();
            bool done = false;
            do
            {
                try
                {
                    Console.Write(" 1: 1 to 12       2: 13 to 24       3: 25 to 36 ? ");
                    var input = Console.ReadLine();

                    if (input == "1")
                    {
                        money += BetFunction(random, money, 1);
                        done = true;
                    }
                    else if (input == "2")
                    {
                        money += BetFunction(random, money, 2);
                        done = true;
                    }
                    else if (input == "3")
                    {
                        money += BetFunction(random, money, 3);
                        done = true;
                    }

                    else
                    {
                        Menu.ClearCompletely();
                        continue;
                    }
                }

                catch (Exception)
                {
                    Menu.ClearCompletely();
                    continue;
                }
            } while (!done);
            Console.WriteLine("...");
            return money;
        }
    }
}
