using ParkingLot.Enums;
using ParkingLot.Strategies.Interfaces;
using ParkingLot.Utilities;

namespace ParkingLot.Strategies.Implementations;

public class HourlyFeeStrategy : IFeeCalculationStrategy
{
    public decimal CalculateFee(SlotSize slotSize, DateTime entryTime, DateTime exitTime)
    {
        var hourlySlotRate = SlotRateMapper.GetSlotRate(slotSize);
        return (Decimal)Math.Ceiling((exitTime - entryTime).TotalHours) * hourlySlotRate;
    }
}
