class Card
{
    public Card(Suit suit, Rank rank)
    {
        Suit = suit;
        Rank = rank;
    }

    public Suit Suit { get; init; }
    public Rank Rank { get; init; }
}