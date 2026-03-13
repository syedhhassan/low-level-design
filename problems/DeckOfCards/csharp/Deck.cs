class Deck
{
    private readonly List<Card> _cards = new();

    public Deck()
    {
        foreach (Suit suit in Enum.GetValues<Suit>())
        {
            foreach (Rank rank in Enum.GetValues<Rank>())
            {
                _cards.Add(new Card(suit, rank));
            }
        }
    }

    public void Shuffle()
    {
        Random random = new();
        _cards.Shuffle(random);
    }

    public Card? Draw()
    {
        if (_cards.Count == 0)
            return null;

        Card card = _cards[^1];
        _cards.RemoveAt(_cards.Count - 1);
        return card;
    }
}