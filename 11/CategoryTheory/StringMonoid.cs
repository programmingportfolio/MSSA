namespace CategoryTheory
{
    class StringMonoid : IMonoid<StringMonoid>
    {
        private StringMonoid(string value)
        {
            Value = value;
        }

        public string Value { get; set; }
        public StringMonoid Mempty => Pack("");

        public StringMonoid Mappend(StringMonoid other) => Pack(Value + other.Value);

        public static StringMonoid Pack(string s)
            => new StringMonoid(s);
    }
}
