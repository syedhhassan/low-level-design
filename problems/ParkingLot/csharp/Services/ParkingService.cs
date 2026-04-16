using ParkingLot.Enums;
using ParkingLot.Models;
using ParkingLot.Repositories;
using ParkingLot.Strategies.Interfaces;
using ParkingLot.Utilities;

namespace ParkingLot.Services;

public class ParkingService
{
    private readonly List<ParkingRecord> _parkingRecords = new();
    private readonly ISlotRepository _slotRepository;
    private readonly ISlotAssignmentStrategy _slotAssignmentStrategy;
    private readonly IFeeCalculationStrategy _feeCalculationStrategy;

    public ParkingService(ISlotRepository slotRepository, ISlotAssignmentStrategy slotAssignmentStrategy, IFeeCalculationStrategy feeCalculationStrategy)
    {
        _slotRepository = slotRepository;
        _slotAssignmentStrategy = slotAssignmentStrategy;
        _feeCalculationStrategy = feeCalculationStrategy;
    }

    public ParkingRecord? ParkVehicle(Vehicle vehicle)
    {
        var availableSlots = _slotRepository.GetAvailableSlots(SlotSizeMapper.GetSlotSize(vehicle.Type));
        var requiredSlot = _slotAssignmentStrategy.SelectSlot(availableSlots);
        if (requiredSlot == null)
            return null;

        var parkingRecord = new ParkingRecord(vehicle, requiredSlot, DateTime.Now);
        _parkingRecords.Add(parkingRecord);
        _slotRepository.UpdateSlotStatus(requiredSlot.Id, SlotStatus.Occupied);
        return parkingRecord;
    }

    public decimal ExitVehicle(string licensePlate)
    {
        var parkingRecord = _parkingRecords.FirstOrDefault(x => x.Vehicle.LicensePlate == licensePlate && x.ExitTime == null);
        if (parkingRecord == null)
            throw new InvalidOperationException("No vehicle data available!");
        parkingRecord.ExitTime = DateTime.Now;
        var fee = parkingRecord.CalculateFee(_feeCalculationStrategy);
        _slotRepository.UpdateSlotStatus(parkingRecord.Slot.Id, SlotStatus.Available);
        return fee;
    }
}
