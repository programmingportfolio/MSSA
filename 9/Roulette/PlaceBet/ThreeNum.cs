using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.PlaceBet
{
    struct ThreeNum : IBet
    {

        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var generate = random.Next(1, 37);
            Console.WriteLine($"Result: {RouletteTable.PrintName(generate)}");
            int min;
            int max;
            int middle;
            if (one == 1)
            {

                min = one;
                max = one + 2;
                middle = one + 1;
            }
            else if(one == 36)
            {
                min = one - 2;
                max = one;
                middle = one - 1;
            }
            else
            {
                min = one - 1;
                max = one + 1;
                middle = one;
            }

            if(generate == middle || generate == min || generate == max)
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
            var diff = Payouts.ElevenToOne(money) - money;
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
                    Console.Write("Pick # by Street ? ");
                    var input = int.Parse(Console.ReadLine());
                    if(input >= 1 || input <= 36)
                    {
                        
                        done = true;
                        money += BetFunction(random, money, input);

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
