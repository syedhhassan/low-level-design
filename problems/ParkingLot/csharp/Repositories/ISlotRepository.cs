using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Repositories;

public interface ISlotRepository
{
    List<Slot> GetAvailableSlots(SlotSize slotSize);

    void UpdateSlotStatus(Guid Id, SlotStatus slotStatus);
}
