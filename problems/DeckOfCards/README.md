# Deck of Cards

## Problem
Models a standard deck of 52 playing cards with uniform random shuffling and draw functionality.

## Entities
- `Suit` — enum (Clubs, Diamonds, Hearts, Spades)
- `Rank` — enum (Two through Ace)
- `Card` — immutable model with a Suit and Rank
- `Deck` — holds 52 cards, supports shuffling and drawing

## Key Design Decisions

### Why enums for Suit and Rank?
Both represent a fixed, known set of values. Enums prevent invalid values
from being introduced and can be iterated over to build the deck programmatically.

### Why is Card immutable?
A card's identity is fixed at creation. A Two of Clubs can never become
any other card, so allowing mutation after construction would misrepresent reality.

### Why does Draw() return Card? instead of throwing?
An empty deck is an expected game state, not a bug. Returning null signals
to the caller that the deck is empty — which is closer to how a real deck
of cards works than throwing an exception.

### Why Fisher-Yates over OrderBy(x => random.Next())?
Two reasons. First, correctness: sorting algorithms assume comparisons are
stable and consistent. Regenerating a random key per comparison violates
this, producing biased orderings. Second, performance: Fisher-Yates is O(n)
vs O(n log n) for a sort.

### Why ListExtensions over a Utility class?
Extension methods let Shuffle() be called directly on the list, which is
more idiomatic C#. Coding to IList<T> instead of List<T> makes it reusable
across arrays and other list types.