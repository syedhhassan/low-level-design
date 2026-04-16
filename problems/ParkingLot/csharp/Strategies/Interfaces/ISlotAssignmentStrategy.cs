using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Strategies.Interfaces;

public interface ISlotAssignmentStrategy
{
    Slot? SelectSlot(List<Slot> availableSlots);
}
