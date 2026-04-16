# Low Level Design

A collection of LLD problems implemented in C#, focusing on clean architecture, SOLID principles, and design patterns.

## Problems

| Problem | Concepts |
|---------|----------|
| [Deck of Cards](problems/DeckOfCards) | Enums, Immutability, Fisher-Yates Shuffle |
| [Tic Tac Toe](problems/TicTacToe) | Nullable types, Fail-fast, SRP |
| [Parking Lot](problems/ParkingLot) | Strategy Pattern, Repository Pattern, DI |
| [Key Value Store](problems/KeyValueStore) | In-memory storage, Lazy expiry, Redis semantics |

## Structure
Each problem lives in its own folder with a README explaining design decisions and a language-specific subfolder for the implementation.

```
problems/
└── ProblemName/
    ├── README.md
    └── csharp/
```

## Languages
- C# / .NET

More languages will be added over time.
