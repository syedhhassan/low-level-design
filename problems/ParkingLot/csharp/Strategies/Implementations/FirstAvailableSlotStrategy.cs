using ParkingLot.Models;

namespace ParkingLot.Strategies.Implementations;

public class FirstAvailableSlotStrategy : ISlotAssignmentStrategy
{
    public Slot? SelectSlot(List<Slot> availableSlots)
    {
        return availableSlots.FirstOrDefault();
    }
}
