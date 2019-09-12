using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette.PlaceBet
{
    struct SixNum : IBet
    {

        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var generate = random.Next(1, 37);
            Console.WriteLine($"Result: {RouletteTable.PrintName(generate)}");
            if (Enumerable.Range(1, 7).Contains(generate) && one == 1 && four == 0)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(7, 13).Contains(generate) && two == 1 && four == 0)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(13, 19).Contains(generate) && three == 1)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(19, 25).Contains(generate) && four == 1 && one == 0 && two == 0)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(25, 31).Contains(generate) && one == 1 && four == 1)
            {
                return OnWin(money);
            }
            if (Enumerable.Range(31, 37).Contains(generate) && two == 1 && four == 1)
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
            var diff = Payouts.FiveToOne(money) - money;
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
                    Console.Write(" 1: 1 to 6       2: 7 to 12       3: 13 to 18       4: 19 to 24       5: 25 to 30       6: 31 to 36 ? ");
                    var input = Console.ReadLine();

                    if (input == "1")
                    {
                        money += BetFunction(random, money, 1);
                        done = true;
                    }
                    else if (input == "2")
                    {
                        money += BetFunction(random, money, 0, 1);
                        done = true;
                    }
                    else if (input == "3")
                    {
                        money += BetFunction(random, money, 0, 0, 1);
                        done = true;
                    }

                    else if (input == "4")
                    {
                        money += BetFunction(random, money, 0, 0, 0, 1);
                        done = true;
                    }

                    else if (input == "5")
                    {
                        money += BetFunction(random, money, 1, 0, 0, 1);
                        done = true;
                    }

                    else if (input == "6")
                    {
                        money += BetFunction(random, money, 0, 1, 0, 1);
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
