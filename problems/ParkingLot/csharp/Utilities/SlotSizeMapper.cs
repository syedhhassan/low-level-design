using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Utilities;

public static class SlotSizeMapper
{
    public static SlotSize GetSlotSize(VehicleType vehicleType)
    {
        return vehicleType switch
        {
            VehicleType.Bike => SlotSize.Small,
            VehicleType.Car => SlotSize.Medium,
            VehicleType.Truck => SlotSize.Large,
            _ => throw new ArgumentException($"Unknown vehicle type: {vehicleType}")
        };
    }
}
