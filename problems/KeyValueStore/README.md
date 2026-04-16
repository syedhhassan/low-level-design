# Mini Redis (KeyValueStore)

## Problem
An in-memory key-value store modelled after Redis, implemented as a
console application supporting core Redis commands.

## Commands Supported
- `SET key value` — stores a value
- `GET key` — retrieves a value, null if not found
- `DEL key` — removes a key, returns 1 if deleted, 0 if not found
- `EXPIRE key seconds` — sets a TTL on a key
- `TTL key` — returns remaining TTL (-1 if no expiry, -2 if key missing)
- `INCR key` — increments integer value, initializes to 1 if missing
- `DECR key` — decrements integer value, throws if key missing
- `KEYS` — lists all non-expired keys
- `FLUSHALL` — clears the entire store

## Expiration Strategy
Keys are checked and cleaned on access (lazy expiry) rather than via
a background process. This avoids overhead of a separate cleanup thread
while ensuring expired keys are never returned to the caller.

## Known Limitations
Single-threaded. A production implementation would require locking or
`ConcurrentDictionary` to handle concurrent reads and writes safely.
