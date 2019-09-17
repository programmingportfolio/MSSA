using System;
using System.Collections.Generic;
using System.Text;

namespace CategoryTheory
{
    class Maybe<T> : IMonoid<Maybe<T>> 
        where T : IMonoid<T>
    {
        private Maybe()
        {
            IsNothing = true;
        }

        private Maybe(T value)
        {
            Value = value;
            IsNothing = false;
        }

        private T Value { get; }

        public bool IsNothing { get; }
        public bool IsJust => !IsNothing;

        public T FromMaybe(T alternative)
        {
            if (IsNothing)
            {
                return alternative;
            }
            else
            {
                return Value;
            }
        }
        //=> IsNothing ? alternative : Value;
        public static Maybe<T> Just(T val)
            => new Maybe<T>(val);


        public static Maybe<T> Nothing
            => new Maybe<T>();

        public Maybe<T> Mappend(Maybe<T> other)
        {
            if (IsNothing && other.IsNothing) return Nothing;
            else if (other.IsNothing) return this;
            else if (this.IsNothing) return other;
            else return Just(Value.Mappend(other.Value));
        }
        public Maybe<T> Mempty => Nothing;
    }
}
