namespace CategoryTheory
{
    class IntegerAddition : IMonoid<IntegerAddition>
    {
        private IntegerAddition(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public IntegerAddition Mempty => Pack(0);

        public IntegerAddition Mappend(IntegerAddition other) => Pack(Value + other.Value);
        //same public IntegerAddition Mappend(IntegerAddition other) => new IntegerAddition(Value + other.Value);

        public static IntegerAddition Pack(int i)
            => new IntegerAddition(i);

    }
}
