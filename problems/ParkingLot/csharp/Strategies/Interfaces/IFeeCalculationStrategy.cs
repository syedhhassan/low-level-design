using ParkingLot.Enums;

namespace ParkingLot.Strategies.Interfaces;

public interface IFeeCalculationStrategy
{
    decimal CalculateFee(SlotSize slotSize, DateTime entryTime, DateTime exitTime);
}
