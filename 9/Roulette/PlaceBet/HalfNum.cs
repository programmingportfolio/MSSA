using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.PlaceBet
{
    struct HalfNum : IBet
    {
        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var generate = random.Next(0, 38);
            Console.WriteLine($"Result: {RouletteTable.PrintName(generate)}");
            if(one == 1)
            {
                if(generate > 0 && generate < 19)
                {
                    return OnWin(money);
                }
                else
                {
                    return OnLose(money);
                }
            }
            else if(one == 2)
            {
                if(generate > 18 && generate < 37)
                {
                    return OnWin(money);
                }
                else
                {
                    return OnLose(money);
                }

            }
            else
            {
                return OnLose(money);
            }
        }

        public decimal OnLose(decimal money)
        {
            Console.WriteLine("You Lost.");
            var diff = 0;
            return diff;
        }

        public decimal OnWin(decimal money, int option = 0)
        {
            Console.WriteLine("You won!");
            var diff = 0;
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
                    Console.Write("1: Lows 1-18, 2: Highs 19-36");
                    var input = Console.ReadLine();
                    if(input == "1")
                    {

                        done = true;
                        money += BetFunction(random, money, 1);
                        return money;

                    }

                    else if(input == "2")
                    {
                        done = true;
                        money += BetFunction(random, money, 2);
                        return money;
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
