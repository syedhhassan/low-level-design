using ParkingLot.Enums;

namespace ParkingLot.Utilities;

public static class SlotRateMapper
{
    public static decimal GetSlotRate(SlotSize slotSize)
    {
        return slotSize switch
        {
            SlotSize.Small => 10M,
            SlotSize.Medium => 20M,
            SlotSize.Large => 30M,
            _ => throw new ArgumentException($"Unknown Slot Size: {slotSize}")
        };
    }
}
