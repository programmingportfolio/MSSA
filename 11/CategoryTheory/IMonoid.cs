namespace CategoryTheory
{
    interface IMonoid<T>
    {
        T Mempty { get; }
        T Mappend(T other);
    }
}
