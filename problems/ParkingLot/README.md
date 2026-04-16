# Parking Lot

## Problem
Model a parking lot system that can park and exit vehicles, assign
slots based on vehicle type, and calculate fees based on duration.

## Entities
- `Vehicle` — holds license plate and vehicle type
- `Slot` — holds size, floor number, and availability status
- `ParkingRecord` — tracks a vehicle's entry, exit, and fee calculation
- `ParkingService` — orchestrates parking and exit operations
- `SlotRepository` — manages slot data and availability queries

## Architecture

### Strategy Pattern
Both slot assignment and fee calculation are modelled as strategies,
making them swappable without modifying core logic.
- `ISlotAssignmentStrategy` — implemented by `FirstAvailableSlotStrategy`
- `IFeeCalculationStrategy` — implemented by `HourlyFeeStrategy`

### Repository Pattern
`ISlotRepository` abstracts slot data access, keeping `ParkingService`
decoupled from storage concerns.

### Utilities
- `SlotSizeMapper` — maps `VehicleType` to `SlotSize`
- `SlotRateMapper` — maps `SlotSize` to hourly rate

## Key Design Decisions
- `ParkingRecord` owns `CalculateFee()` — the record has all the data
  needed (entry time, exit time, slot size) so fee calculation belongs there
- `_parkingRecords` is owned internally by `ParkingService` — records
  are a service concern, not an external dependency
- Slots are injected into `SlotRepository` — they represent physical
  lot configuration set up at startup, not a service responsibility