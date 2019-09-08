using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace BisectionAlgorithm
{
    /*
     * What is the maximum number of guesses you need to guess a number between 1 and 1000? Recall that log2 1000 = 9.966 and that 210 = 1024.
     * Maximum number of guesses is 9 because it cannot reach 10.
     */

    //The computer in this situation has losing odds over the user because the user could make mistakes.
    internal class App
    {
        static List<string> guessPrevious = new List<string>();
        static List<int> guessComputer = new List<int>();
        static List<string> guessHint = new List<string>();
        int guess;
        static bool outcome;
        static List<int> list = new List<int>();
        static string response;
        internal void Run()
        {
            App.list = GenerateList(0, 11);
            var random = new Random();

            do
            {
                guess = UserLoop();
                App.outcome = FirstGuess(random, guess);

            } while (!App.outcome);
            App.outcome = false;
            Console.WriteLine("You win!");
            App.guessHint = new List<string>();
            App.guessPrevious = new List<string>();
            Thread.Sleep(1000);





            Console.Clear();
            App.list = GenerateList(0, 101);
            var answer = random.Next(1, 101);
            do
            {
                guess = UserLoop();
                App.outcome = Guess(answer, guess, list);

            } while (!App.outcome);

            Console.WriteLine("You win!");
            App.outcome = false;
            Thread.Sleep(1000);





            App.list = GenerateList(0, 101);
            answer = UserPick();
            guess = ComputerLoop(random);
            App.outcome = UserEvaluation(answer, guess);
            while (!App.outcome)
            {
                Console.WriteLine("a");
                guess = ComputerLoop(random, App.response);
                App.outcome = UserEvaluation(answer, guess);
            }
            Console.WriteLine("You win!");
            Thread.Sleep(1000);
        }







        internal int ComputerLoop(Random random, string response = null)
        {
            try
            {
                if (response == null)
                {
                    var index = random.Next(1, 101);
                    var generate = list[index];
                    App.guessComputer.Add(generate);
                    return generate;
                }
                else
                {
                    if (response == "Higher")
                    {
                        var previousIndex = App.guessComputer.Last();
                        App.list.RemoveRange(0, previousIndex + 1);
                        var index = random.Next(0, list.Count);
                        var generate = App.list[index];
                        App.guessComputer.Add(index);
                        return generate;
                    }
                    else if (response == "Lower")
                    {
                        var previousIndex = App.guessComputer.Last();
                        App.list.RemoveRange(previousIndex, App.list.Count - previousIndex); // start, list.Count - start
                        var index = random.Next(0, list.Count);
                        var generate = App.list[index];
                        App.guessComputer.Add(index);
                        return generate;
                    }
                    
                }
            }
            catch (Exception)
            {
                return 0;
            }
            return 0;

        }

        private bool UserEvaluation(int answer, int guess)
        {
            var responses = new List<string>() { "1", "2", "3" };
            bool match = false;
            do
            {
                Console.Clear();
                Console.WriteLine($"Computer guess: {guess} Your pick: {answer}");
                Console.WriteLine("Were they right? 1: Yes 2: Lower 3: Higher");
                Console.Write("$ ");
                var r = Console.ReadLine();
                App.response = r;
                foreach (string response in responses)
                {
                    if (r == response)
                    {
                        match = true;
                    }
                }
                if (!match)
                {
                    Console.WriteLine("Try again");
                    Thread.Sleep(1000);
                }
            }
            while (!match);

            if (App.response == "1")
            {
                App.response = "Yes";
                return true;
            }
            else if (App.response == "2")
            {
                App.response = "Lower";
            }
            else if (App.response == "3")
            {
                App.response = "Higher";
            }

            return false;
        }

        internal int UserPick()
        {
            Console.Clear();
            bool done = false;
            do
            {
                try
                {
                    Console.Write("\nPick a number: ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    var guessIndex = App.list.FindIndex(x => x == guess);

                    if (guessIndex > App.list.Count - 1 || guessIndex < 0)
                    {
                        Console.WriteLine("Outside Range of List");
                    }
                    else
                    {
                        done = true;
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Try again..");
                    continue;
                }
            }
            while (!done);
            return guess;
        }
        internal int UserLoop()
        {
            bool done = false;
            Console.Clear();
            Console.WriteLine("Previous guesses\n");
            var guessIndex = App.list.FindIndex(x => x == guess);
            if (App.guessPrevious != null)
            {
                foreach (string s in App.guessPrevious)
                {
                    Console.Write($"{s} ");
                }
                foreach (string s in App.guessHint)
                {
                    Console.Write($"{s} ");
                }
            }



            do
            {
                try
                {
                    Console.Write("\nGuess a number: ");
                    guess = Convert.ToInt32(Console.ReadLine());
                    done = true;



                    if (guessIndex > App.list.Count - 1 || guess < 0)
                    {
                        Console.WriteLine("Outside Range of List");
                    }

                }
                catch (FormatException)
                {
                    Console.WriteLine("Try again..");
                    continue;
                }
            }
            while (!done);
            return guess;
        }

        bool FirstGuess(Random random, int guess = 4, List<int> list = null)
        {
            var answer = 4;


            if (answer == guess)
            {
                return true;
            }

            int guessIndex = App.list.FindIndex(x => x == guess);
            int answerIndex = App.list.FindIndex(x => x == answer);
            if (guess > answer)
            {
                App.list.RemoveRange(guessIndex, App.list.Count - guessIndex); // previous, App.list.Count - previous
                var high = "Too high";
                var conv = $"{guess}  ";
                Console.WriteLine(high);
                App.guessHint.Add(high);
                App.guessPrevious.Add(conv);
                Console.WriteLine("List printout");
                foreach (int i in App.list)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine("");
                Thread.Sleep(1000);
                return false;
            }
            else if (guess < answer)
            {
                App.list.RemoveRange(0, guessIndex + 1);
                var low = "Too low  ";
                var conv = $"{guess}  ";
                Console.WriteLine(low);
                App.guessHint.Add(low);
                App.guessPrevious.Add(conv);
                Console.WriteLine("List printout");
                foreach (int i in App.list)
                {
                    Console.Write($"{i} ");
                }
                Console.WriteLine("");
                Thread.Sleep(1000);
                return false;
            }

            else if (guess < answer && guess + 1 == App.list.Count)
            {
                Console.WriteLine("Try again.. Out of range");
            }
            return false;
        }
        internal bool Guess(int answer, int guess, List<int> list)
        {
            try
            {
                if (answer == guess)
                {
                    return true;
                }

                int guessIndex = App.list.FindIndex(x => x == guess);
                int answerIndex = App.list.FindIndex(x => x == answer);
                if (guess > answer)
                {
                    App.list.RemoveRange(guessIndex, App.list.Count - guessIndex); // previous, App.list.Count - previous
                    var high = "Too high";
                    var conv = $"{guess}  ";
                    Console.WriteLine(high);
                    App.guessHint.Add(high);
                    App.guessPrevious.Add(conv);
                    Console.WriteLine("List printout");
                    foreach (int i in list)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    return false;
                }
                else if (guess < answer)
                {
                    App.list.RemoveRange(0, guessIndex + 1);
                    var low = "Too low  ";
                    var conv = $"{guess}  ";
                    Console.WriteLine(low);
                    App.guessHint.Add(low);
                    App.guessPrevious.Add(conv);
                    Console.WriteLine("List printout");
                    foreach (int i in list)
                    {
                        Console.Write($"{i} ");
                    }
                    Console.WriteLine("");
                    Thread.Sleep(1000);
                    return false;
                }

                else if (guess < answer && guess + 1 == App.list.Count)
                {
                    Console.WriteLine("Try again.. Out of range");
                }
            }
            catch(Exception)
            {
                Console.WriteLine("Try again.");
                return false;
            }
            Console.WriteLine("Try again.");
            return false;
        }


        internal List<int> GenerateList(int start, int end)
        {
            var list = new List<int>();
            for (int i = start; i < end; i++)
            {
                list.Add(i);
            }
            return list;
        }

    }
}
