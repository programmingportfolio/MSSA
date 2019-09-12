using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Roulette.PlaceBet
{
    struct BetweenNum : IBet
    {
        int odds;
        List<int> zeroPicks;

        public decimal UserLoop(Random random, decimal money)
        {
            Menu.ClearCompletely();
            Console.Write("Pick a number for more options 1-36 or 0 or 00: ");
            bool done = false;
            do
            {
                try
                {
                    var input = Console.ReadLine();

                    if (input == "0")
                    {
                        money += BetFunction(random, money, 0);
                        done = true;
                        return money;
                    }

                    else if (input == "00")
                    {
                        money += BetFunction(random, money, 37);

                        done = true;
                        return money;
                    }

                    else if (int.Parse(input) > 0 && int.Parse(input) < 37)
                    {
                        var inputnum = int.Parse(input);
                        money += BetFunction(random, money, inputnum, 0, 0, 1);

                        done = true;
                        return money;
                    }

                    else
                    {
                        Menu.ClearCompletely();
                        Console.WriteLine("Improper Input");
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
        public decimal BetFunction(Random random, decimal money, int one = 0, int two = 0, int three = 0, int four = 0)
        {

            var betTable = Generate.BetNumbers();
            var generate = random.Next(0, 38);
            var arr1 = BetTable.NumbersArray1;
            var arr2 = BetTable.NumbersArray2;
            var arr3 = BetTable.NumbersArray3;
            var arrName1 = new Dictionary<string, int>();
            var arrName2 = new Dictionary<string, int>();
            var arrName3 = new Dictionary<string, int>();
            var arrName4 = new Dictionary<string, int>();

            int index1 = Array.FindIndex(arr1, position => position == one);
            int index2 = Array.FindIndex(arr2, position => position == one);
            int index3 = Array.FindIndex(arr3, position => position == one);
            bool null1 = index1 != 0;
            bool null2 = index2 != 0;
            bool null3 = index3 != 0;
            int total = index1 + index2 + index3;

            if (one == 0)
            {
                var (zeroPicks, odds) = HandleZeros(one);
                this.zeroPicks = zeroPicks;
                this.odds = odds;
            }
            else if (one == 37)
            {
                var (zeroPicks, odds) = HandleZeros(one);
                this.zeroPicks = zeroPicks;
                this.odds = odds;
            }

            else if (four == 1)
            {
                var (odds, arrName12, arrName22, arrName32, arrName42) = HandleFour(total, arr1, arr2, arr3, index1, index2, index3, arrName1, arrName2, arrName3, arrName4, null1, null2, null3);
                this.odds = odds;
                arrName1 = arrName12;
                arrName2 = arrName22;
                arrName3 = arrName32;
            }

            else if (two == 1)
            {
                var (odds, arrName12, arrName22, arrName32, arrName42) = HandleTwo(total, arr1, arr2, arr3, index1, index2, index3, arrName1, arrName2, arrName3, arrName4, null1, null2, null3);
                this.odds = odds;
                arrName1 = arrName12;
                arrName2 = arrName22;
                arrName3 = arrName32;
            }

            if (one == 0 || one == 37)
            {
                bool match = false;
                foreach (var item in this.zeroPicks)
                {
                    Console.WriteLine($" Winning Number = {generate}");
                    if (item == generate)
                    {
                        match = true;
                    }
                }
                if (match)
                {
                    return OnWin(money, this.odds);
                }
                else
                {
                    return OnLose(money);
                }
            }
            else if (four == 1)
            {
                return WinningDeterminationFour(arrName1, arrName2, arrName3, arrName4, generate, money);
            }

            else if (two == 1)
            {
                return WinningDeterminationTwo(arrName1, arrName2, arrName3, arrName4, generate, money);
            }

            Console.WriteLine("...");
            return money;
        }

        public decimal OnLose(decimal money)
        {
            Console.WriteLine("You Lost.");
            var diff = -(money);
            return diff;
        }

        public decimal OnWin(decimal money, int option)
        {
            decimal diff = 0;
            Console.WriteLine("You won!");
            if (option == 17)
            {
                diff += Payouts.SeventeenToOne(money) - money;
            }
            else if (option == 11)
            {
                diff += Payouts.ElevenToOne(money) - money;
            }

            else if (option == 8)
            {
                diff += Payouts.EightToOne(money) - money;
            }
            return diff;
        }

        decimal WinningDeterminationTwo(Dictionary<string, int> arrName1, Dictionary<string, int> arrName2, Dictionary<string, int> arrName3, Dictionary<string, int> arrName4, int generate, decimal money)
        {
            if (arrName2.Count > 0)
            {
                {
                    Console.WriteLine("Pick between these.");
                    Console.Write(" 1: ");
                    foreach (var item in arrName1)
                    {
                        Console.Write($" {item.Key} ");
                    }
                    Console.WriteLine("");
                    Console.Write(" 2: ");
                    foreach (var item in arrName2)
                    {
                        Console.Write($" {item.Key} ");
                    }
                    Console.WriteLine("");
                    bool done = false;
                    bool match = false;

                    do
                    {
                        Menu.ClearForFeedback();
                        Console.Write(" $");
                        var input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.WriteLine($" Winning Number = {generate}");
                            foreach (var item in arrName1)
                            {
                                if (item.Value == generate)
                                {
                                    match = true;
                                }
                            }

                            if (match)
                            {
                                done = true;
                                return OnWin(money, this.odds);
                            }
                            else
                            {
                                done = true;
                                return OnLose(money);
                            }
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine($" Winning Number = {generate}");
                            foreach (var item in arrName2)
                            {
                                if (item.Value == generate)
                                {
                                    match = true;
                                }
                            }

                            if (match)
                            {
                                done = true;
                                return OnWin(money, this.odds);
                            }
                            else
                            {
                                done = true;
                                return OnLose(money);
                            }
                        }

                        else
                        {
                            Menu.UserFeedback("Invalid input.\n Try again.");
                            continue;
                        }

                    }
                    while (!done);

                }
            }

            else if (arrName1.Count > 0)
            {
                bool match = false;
                Menu.ClearForFeedback();
                Console.Write(" $");
                var input = Console.ReadLine();
                Console.WriteLine($" Winning Number = {generate}");
                foreach (var item in arrName1)
                {
                    if (item.Value == generate)
                    {
                        match = true;
                    }
                }

                if (match)
                {
                    return OnWin(money, this.odds);
                }
                else
                {
                    return OnLose(money);
                }

            }
            Console.WriteLine("...");
            return money;
        }

        decimal WinningDeterminationFour(Dictionary<string, int> arrName1, Dictionary<string, int> arrName2, Dictionary<string, int> arrName3, Dictionary<string, int> arrName4, int generate, decimal money)
        {
            if (arrName4.Count > 0)
            {
                Console.WriteLine("Pick between these.");
                Console.Write(" 1: ");
                foreach (var item in arrName1)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                Console.Write(" 2: ");
                foreach (var item in arrName2)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                Console.Write(" 3: ");
                foreach (var item in arrName3)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                Console.Write(" 4: ");
                foreach (var item in arrName4)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                bool done = false;
                bool match = false;

                do
                {
                    Menu.ClearForFeedback();
                    Console.Write(" $");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName1)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName2)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName3)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else if (input == "4")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName4)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else
                    {
                        Menu.UserFeedback("Invalid input.\n Try again.");
                        continue;
                    }

                }
                while (!done);

            }

            else if (arrName3.Count > 0)
            {
                Console.WriteLine("Pick between these.");
                Console.Write(" 1: ");
                foreach (var item in arrName1)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                Console.Write(" 2: ");
                foreach (var item in arrName2)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                Console.Write(" 3: ");
                foreach (var item in arrName3)
                {
                    Console.Write($" {item.Key} ");
                }
                Console.WriteLine("");
                bool done = false;
                bool match = false;

                do
                {
                    Menu.ClearForFeedback();
                    Console.Write(" $");
                    var input = Console.ReadLine();
                    if (input == "1")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName1)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else if (input == "2")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName2)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }
                    else if (input == "3")
                    {
                        Console.WriteLine($" Winning Number = {generate}");
                        foreach (var item in arrName3)
                        {
                            if (item.Value == generate)
                            {
                                match = true;
                            }
                        }

                        if (match)
                        {
                            done = true;
                            return OnWin(money, this.odds);
                        }
                        else
                        {
                            done = true;
                            return OnLose(money);
                        }
                    }

                    else
                    {
                        Menu.UserFeedback("Invalid input.\n Try again.");
                        continue;
                    }

                }
                while (!done);

            }

            else if (arrName2.Count > 0)
            {
                {
                    Console.WriteLine("Pick between these.");
                    Console.Write(" 1: ");
                    foreach (var item in arrName1)
                    {
                        Console.Write($" {item.Key} ");
                    }
                    Console.WriteLine("");
                    Console.Write(" 2: ");
                    foreach (var item in arrName2)
                    {
                        Console.Write($" {item.Key} ");
                    }
                    Console.WriteLine("");
                    bool done = false;
                    bool match = false;

                    do
                    {
                        Menu.ClearForFeedback();
                        Console.Write(" $");
                        var input = Console.ReadLine();
                        if (input == "1")
                        {
                            Console.WriteLine($" Winning Number = {generate}");
                            foreach (var item in arrName1)
                            {
                                if (item.Value == generate)
                                {
                                    match = true;
                                }
                            }

                            if (match)
                            {
                                done = true;
                                return OnWin(money, this.odds);
                            }
                            else
                            {
                                done = true;
                                return OnLose(money);
                            }
                        }
                        else if (input == "2")
                        {
                            Console.WriteLine($" Winning Number = {generate}");
                            foreach (var item in arrName2)
                            {
                                if (item.Value == generate)
                                {
                                    match = true;
                                }
                            }

                            if (match)
                            {
                                done = true;
                                return OnWin(money, this.odds);
                            }
                            else
                            {
                                done = true;
                                return OnLose(money);
                            }
                        }

                        else
                        {
                            Menu.UserFeedback("Invalid input.\n Try again.");
                            continue;
                        }

                    }
                    while (!done);

                }
            }
            Console.WriteLine("...");
            return money;
        }

        public (int, Dictionary<string, int>, Dictionary<string, int>, Dictionary<string, int>, Dictionary<string, int>) HandleFour(int total, int[] arr1, int[] arr2, int[] arr3, int index1, int index2, int index3, Dictionary<string, int> arrName1, Dictionary<string, int> arrName2, Dictionary<string, int> arrName3, Dictionary<string, int> arrName4, bool null1, bool null2, bool null3)
        {
            if (total == 0)
            {
                if (null1)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index1 + 1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index1]), arr2[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index1 + 1]), arr2[index1]);
                }
                else if (null2)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index2]), arr1[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index2 + 1]), arr1[index2 + 1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);

                    arrName2.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2 - 1]);
                    arrName2.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);
                    arrName2.Add(RouletteTable.PrintName(arr3[index2]), arr3[index2]);
                    arrName2.Add(RouletteTable.PrintName(arr3[index2 + 1]), arr3[index2 + 1]);
                }
                else if (null3)
                {
                    arrName1.Add(RouletteTable.PrintName(arr2[index3]), arr2[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index3 + 1]), arr2[index3 + 1]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3 + 1]), arr3[index3 + 1]);
                }
            }

            else if (total == 11)
            {
                if (null1)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index1 - 1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index1]), arr2[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index1 - 1]), arr2[index1]);
                }
                else if (null2)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index2]), arr1[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index2 - 1]), arr1[index2 - 1]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);

                    arrName2.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                    arrName2.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);
                    arrName2.Add(RouletteTable.PrintName(arr3[index2]), arr3[index2]);
                    arrName2.Add(RouletteTable.PrintName(arr3[index2 - 1]), arr3[index2 - 1]);
                }
                else if (null3)
                {
                    arrName1.Add(RouletteTable.PrintName(arr2[index3]), arr2[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index3 - 1]), arr2[index3 - 1]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3 - 1]), arr3[index3 - 1]);
                }
            }


            else if (null1)
            {
                arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                arrName1.Add(RouletteTable.PrintName(arr1[index1 - 1]), arr1[index1]);
                arrName1.Add(RouletteTable.PrintName(arr2[index1]), arr2[index1]);
                arrName1.Add(RouletteTable.PrintName(arr2[index1 - 1]), arr2[index1]);

                arrName2.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                arrName2.Add(RouletteTable.PrintName(arr1[index1 + 1]), arr1[index1]);
                arrName2.Add(RouletteTable.PrintName(arr2[index1]), arr2[index1]);
                arrName2.Add(RouletteTable.PrintName(arr2[index1 + 1]), arr2[index1]);


            }
            else if (null2)
            {
                arrName1.Add(RouletteTable.PrintName(arr1[index2]), arr1[index2]);
                arrName1.Add(RouletteTable.PrintName(arr1[index2 - 1]), arr1[index2 - 1]);
                arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                arrName1.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);

                arrName2.Add(RouletteTable.PrintName(arr1[index2]), arr1[index2]);
                arrName2.Add(RouletteTable.PrintName(arr1[index2 + 1]), arr1[index2 + 1]);
                arrName2.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                arrName2.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);


                arrName3.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                arrName3.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);
                arrName3.Add(RouletteTable.PrintName(arr3[index2]), arr3[index2]);
                arrName3.Add(RouletteTable.PrintName(arr3[index2 - 1]), arr3[index2 - 1]);

                arrName4.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2 - 1]);
                arrName4.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);
                arrName4.Add(RouletteTable.PrintName(arr3[index2]), arr3[index2]);
                arrName4.Add(RouletteTable.PrintName(arr3[index2 + 1]), arr3[index2 + 1]);


            }
            else if (null3)
            {
                arrName1.Add(RouletteTable.PrintName(arr2[index3]), arr2[index3]);
                arrName1.Add(RouletteTable.PrintName(arr2[index3 - 1]), arr2[index3 - 1]);
                arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                arrName1.Add(RouletteTable.PrintName(arr3[index3 - 1]), arr3[index3 - 1]);

                arrName2.Add(RouletteTable.PrintName(arr2[index3]), arr2[index3]);
                arrName2.Add(RouletteTable.PrintName(arr2[index3 + 1]), arr2[index3 + 1]);
                arrName2.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                arrName2.Add(RouletteTable.PrintName(arr3[index3 + 1]), arr3[index3 + 1]);
            }
            this.odds = 8;
            return (8, arrName1, arrName2, arrName3, arrName4);
        }

        public (int, Dictionary<string, int>, Dictionary<string, int>, Dictionary<string, int>, Dictionary<string, int>) HandleTwo(int total, int[] arr1, int[] arr2, int[] arr3, int index1, int index2, int index3, Dictionary<string, int> arrName1, Dictionary<string, int> arrName2, Dictionary<string, int> arrName3, Dictionary<string, int> arrName4, bool null1, bool null2, bool null3)
        {
            if (total == 0)
            {
                if (null1)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index1 + 1]), arr1[index1]);
                }
                else if (null2)
                {
                    arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);

                }
                else if (null3)
                {
                    arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3 + 1]), arr3[index3 + 1]);
                }
            }

            else if (total == 11)
            {
                if (null1)
                {
                    arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                    arrName1.Add(RouletteTable.PrintName(arr1[index1 - 1]), arr1[index1]);
                }
                else if (null2)
                {
                    arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                    arrName1.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);

                }
                else if (null3)
                {
                    arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                    arrName1.Add(RouletteTable.PrintName(arr3[index3 - 1]), arr3[index3 - 1]);
                }
            }


            else if (null1)
            {
                arrName1.Add(RouletteTable.PrintName(arr1[index1]), arr1[index1]);
                arrName1.Add(RouletteTable.PrintName(arr1[index1 - 1]), arr1[index1]);

                arrName2.Add(RouletteTable.PrintName(arr2[index1]), arr2[index1]);
                arrName2.Add(RouletteTable.PrintName(arr2[index1 + 1]), arr2[index1]);


            }
            else if (null2)
            {
                arrName1.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                arrName1.Add(RouletteTable.PrintName(arr2[index2 - 1]), arr2[index2 - 1]);

                arrName2.Add(RouletteTable.PrintName(arr2[index2]), arr2[index2]);
                arrName2.Add(RouletteTable.PrintName(arr2[index2 + 1]), arr2[index2 + 1]);


            }
            else if (null3)
            {
                arrName1.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                arrName1.Add(RouletteTable.PrintName(arr3[index3 - 1]), arr3[index3 - 1]);

                arrName2.Add(RouletteTable.PrintName(arr3[index3]), arr3[index3]);
                arrName2.Add(RouletteTable.PrintName(arr3[index3 + 1]), arr3[index3 + 1]);
            }
            this.odds = 8;
            return (8, arrName1, arrName2, arrName3, arrName4);
        }
        public (List<int>, int) HandleZeros(int option)
        {
            var options = new List<int>();
            bool done = false;
            do
            {
                Menu.ClearForFeedback();
                switch (option)
                {
                    case 37:
                        Console.WriteLine(" 1: 00 and 1\n 2: 00 and 2\n 3: 00 and 1 and 2\n 4: 00 and 0\n 5: 00 and 0 and 2");
                        var input = Console.ReadLine();
                        if (input == "1")
                        {
                            options.Add(37);
                            options.Add(1);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input == "2")
                        {
                            options.Add(37);
                            options.Add(2);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input == "3")
                        {
                            options.Add(37);
                            options.Add(1);
                            options.Add(2);
                            this.odds = 11;
                            done = true;
                        }
                        else if (input == "4")
                        {
                            options.Add(0);
                            options.Add(37);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input == "5")
                        {
                            options.Add(0);
                            options.Add(37);
                            options.Add(2);
                            this.odds = 11;
                            done = true;
                        }
                        else
                        {
                            Menu.UserFeedback(" Invald input. \nTry again.");
                            continue;
                        }
                        break;
                    case 0:
                        Console.WriteLine(" 1: 0 and 1\n 2: 0 and 2\n 3: 0 and 1 and 2\n 4: 0 and 00\n 5: 0 and 00 and 2");
                        var input2 = Console.ReadLine();
                        if (input2 == "1")
                        {
                            options.Add(0);
                            options.Add(1);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input2 == "2")
                        {
                            options.Add(0);
                            options.Add(2);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input2 == "3")
                        {
                            options.Add(0);
                            options.Add(1);
                            options.Add(2);
                            this.odds = 11;
                            done = true;
                        }
                        else if (input2 == "4")
                        {
                            options.Add(0);
                            options.Add(37);
                            this.odds = 17;
                            done = true;
                        }
                        else if (input2 == "5")
                        {
                            options.Add(0);
                            options.Add(37);
                            options.Add(2);
                            this.odds = 11;
                            done = true;
                        }
                        else
                        {
                            Menu.UserFeedback(" Invald input. \nTry again.");
                            continue;
                        }
                        break;
                    default:
                        break;
                }
            }
            while (!done);
            return (options, this.odds);
        }
    }
}