# Tic Tac Toe

## Problem
Model a configurable n×n Tic Tac Toe game with turn management, 
win detection across rows, columns and diagonals, and draw detection.

## Entities

### Player
The simplest entity — holds only metadata (id, name). Players exist 
before the game starts and are injected into it.

### Board
A physical entity responsible for holding and managing cell data. 
Takes dimensions as constructor arguments, making it configurable 
beyond the standard 3×3.

### Game
Owns the rules and orchestrates gameplay. Receives players as 
dependencies, creates the board, manages turns, and determines 
win/draw conditions.

### MoveResult
An immutable return model that communicates the outcome of each 
move to the caller — whether valid, and why.

## Key Design Decisions

### Why Symbol? instead of a separate CellState enum?
A separate CellState would be Symbol + one extra state (Empty), 
which introduces redundancy. Symbol? achieves the same thing — 
null means empty, X or O means occupied — while keeping Symbol 
pure to its domain.

### Why does Play() return MoveResult instead of void or bool?
A bool only communicates success or failure. MoveResult carries 
richer context — whether the game is over, who won, or why a move 
was rejected — giving the caller everything it needs to respond.

### Why does Board throw exceptions but Play() returns MoveResult?
Board is a physical entity with hard constraints — out of bounds 
or occupied cells are programming errors, not expected game states. 
Game is a set of rules where invalid moves are expected and should 
be communicated gracefully to the caller.

### Why does Game receive Players instead of creating them?
Players exist before the game starts — the game is for the players, 
not the other way around. Creating players inside Game would invert 
this relationship. Injecting them keeps the dependency correct.

### Win detection
Checks all n rows, n columns, and 2 diagonals. Each check compares 
all cells in a line against the first cell, failing fast on null 
or mismatch.

## What I learned
- Nullable types can replace redundant enums when the extra state 
  is just "absent"
- Physical constraints (Board) warrant exceptions; game rules (Game) 
  warrant result objects
- Dependency Injection isn't just a framework feature — it's about 
  modelling relationships correctly
