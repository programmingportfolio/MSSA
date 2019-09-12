using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.PlaceBet
{
    struct PickNum : IBet
    {
        bool done;
        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {
            var number = random.Next(0, 38);
            Menu.ClearCompletely();
            Console.WriteLine($"Result: {RouletteTable.PrintName(number)}");
            if(one == number)
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

        public decimal OnWin(decimal money, int options = 0)
        {
            Console.WriteLine("You won!");
            var diff = Payouts.ThirtyFiveToOne(money) - money;
            return diff;
        }

        public decimal UserLoop(Random random, decimal money)
        {
            Menu.ClearCompletely();
            this.done = false;
            do
            {
                Console.Write("Pick a number: ");
                var input = Console.ReadLine();
                Console.WriteLine("Enter");
                try
                {
                    var convert = int.Parse(input);

                    if(convert < 38 && convert > 0)
                    money += BetFunction(random, money, convert);
                    this.done = true;
                }
                catch (FormatException)
                {
                    Menu.ClearForFeedback();
                    Menu.UserFeedback("Not a valid input \n Try again.");
                    break;
                }
            }
            while (!this.done);
            return money;
        }
    }
}
