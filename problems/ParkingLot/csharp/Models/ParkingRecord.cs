using ParkingLot.Strategies.Interfaces;

namespace ParkingLot.Models;

public class ParkingRecord
{
    public ParkingRecord(Vehicle vehicle, Slot slot, DateTime entryTime)
    {
        Vehicle = vehicle;
        Slot = slot;
        EntryTime = entryTime;
    }

    public Vehicle Vehicle { get; }
    public Slot Slot { get; }
    public DateTime EntryTime { get; }
    public DateTime? ExitTime { get; set; }

    public decimal CalculateFee(IFeeCalculationStrategy strategy)
    {
        if (ExitTime == null)
            throw new InvalidOperationException("Vehicle has not exited yet!");
        if (EntryTime > ExitTime)
            throw new ArgumentException("Exit time cannot be earlier than entry time.");
        
        return strategy.CalculateFee(Slot.Size, EntryTime, ExitTime.Value);
    }
    
}
