using ParkingLot.Enums;

namespace ParkingLot.Models;

public class Vehicle
{
    public Vehicle(string licensePlate, VehicleType type)
    {
        LicensePlate = licensePlate;
        Type = type;
    }

    public string LicensePlate { get; }
    public VehicleType Type { get; }
}
