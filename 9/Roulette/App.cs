using Roulette.PlaceBet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette
{
    class App
    {
        public void Run()
        {
            (int[] a, string[,] b) = Generate.RouletteTable();
            var rouletteTable = new RouletteTable(a, b);
            var betTable = Generate.BetNumbers();
            Print.Array(betTable.Item1);
            Print.Array(betTable.Item2);
            Print.Array(betTable.Item3);

            var random = new Random();
            decimal money = 1000;

            Menu.ClearCompletely();
            NewGame(random, money);
        }

        public void NewGame(Random random, decimal money)
        {

            ConsoleKeyInfo cki;
            // Prevent example from ending if CTL+C is pressed.
            do
            {
                Menu.ClearForFeedback();
                Console.WriteLine(" Where will you place your bet?");
                Console.Write("  " +
                    "1: 1 #                   " +
                    "\t2: Between #'s         " +
                    "\t3: 6 #'s               " +
                    "\t4: 12 #'s              " +
                    "");
                Console.WriteLine("");
                Console.Write("  " +
                    "5: 3 # Street            " +
                    "\t6: Low/High #'s        " +
                    "\t7: Even or Odd #'s     " +
                    "\t8: Red or BLack");
                Console.WriteLine("\n Press Esc to Exit\n");
                Console.Write("$");
                
                cki = Console.ReadKey();
                if (cki.Key == ConsoleKey.D1)
                {
                    var pick = new PickNum();
                    money += pick.UserLoop(random, money);
                }
                else if(cki.Key == ConsoleKey.D2)
                {
                    var between = new BetweenNum();
                    money += between.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D3)
                {
                    var six = new SixNum();
                    money += six.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D4)
                {
                    var columns = new TwelveNum();
                    money += columns.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D5)
                {
                    var three = new ThreeNum();
                    money += three.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D6)
                {
                    var half = new HalfNum();
                    money += half.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D7)
                {

                    var even = new EvenOdd();
                    money += even.UserLoop(random, money);
                }
                else if (cki.Key == ConsoleKey.D8)
                {
                    var red = new RedBlack();
                    money += red.UserLoop(random, money);
                }
                else
                {
                    Menu.UserFeedback("Invalid input.. \n Try again..");
                    continue;
                }

                Menu.AfterInput();

            } while (money != 100 || cki.Key != ConsoleKey.Escape);
        }
    }
}
