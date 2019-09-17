using System;
using System.Collections.Generic;
using System.Linq;

namespace CategoryTheory
{
    /// <summary>
    /// Abstraction of C# code, the "edge of the language".
    /// 
    /// It would have been nice to have Maybe be inherited by Monoids offering some more type safety and less processing.
    /// 
    /// The main purpose would creating wrappers around the language itself.
    /// 
    /// This is great to know for a functional programming position.
    /// </summary>
    class Program
    {
        static T ID<T>(T t) => t;

        static T Mconcat<T>(IEnumerable<T> list)
            where T : IMonoid<T>
        {
            if (list == null || !list.Any()) return default;

            T accum = list.First().Mempty;

            foreach (var v in list)
            {
                accum = accum.Mappend(v);

            }
            return accum;
        }
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!".Select(c => ID(c)));
            Console.WriteLine("Hello World!".Select(ID).ToArray());

            var ints = Enumerable.Range(1, 10).ToList();

            Console.WriteLine(Mconcat(ints.Select(IntegerAddition.Pack)).Value);
            Console.WriteLine(Mconcat(ints.Select(IntegerMultiplication.Pack)).Value);
            Console.WriteLine(Mconcat(ints.Select(i => StringMonoid.Pack(i.ToString()))).Value);

            //Console.WriteLine($"{Maybe<string>.Nothing.FromMaybe("cat")}");
            //Console.WriteLine($"{Maybe<string>.Just("Dog").FromMaybe("cat")}");
            //Console.WriteLine($"{Maybe<string>.Just("Dog").FromMaybe("cat")}");

            FizzBuzz(21);

        }

        private static void FizzBuzz(int max)
        {
            for (int i = 1; i <= max; i++)
            {
                var s = Mconcat(new List<Maybe<StringMonoid>>
                { i.IfDivisibleBy(3, "Fizz")
                    , i.IfDivisibleBy(5, "Buzz")
                    , i.IfDivisibleBy(7, "Woz") })
                    .FromMaybe(StringMonoid.Pack(i.ToString()))
                    .Value;
                Console.WriteLine(s);
            }
        }
    }

    static class Util
    {
        static public Maybe<StringMonoid> IfDivisibleBy(this int i, int modulus, string s)
        {
            if (i % modulus == 0)
            {
                return Maybe<StringMonoid>.Just(StringMonoid.Pack(s));
            }
            else
            {
                return Maybe<StringMonoid>.Nothing;
            }
        }
    }
}
