using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.PlaceBet
{
    struct EvenOdd : IBet
    {

        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var generate = random.Next(1, 37);
            Menu.ClearCompletely();
            Console.WriteLine($"Result: {generate}");
            if(generate == 0 || generate == 37)
            {
                return OnLose(money);
            }
            else if (one == 1 && generate % 2 == 0)
            {
                return OnWin(money);
            }
            else if (two == 1 && generate % 2 == 1)
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
                    Console.Write("Even 1 or Odd 2 ? ");
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
