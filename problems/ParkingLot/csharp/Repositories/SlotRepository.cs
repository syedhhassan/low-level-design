using ParkingLot.Enums;
using ParkingLot.Models;

namespace ParkingLot.Repositories;

public class SlotRepository : ISlotRepository
{
    private readonly List<Slot> _slots;
    
    public SlotRepository(List<Slot> slots)
    {
        _slots = slots;
    }

    public List<Slot> GetAvailableSlots(SlotSize slotSize)
    {
        return _slots.FindAll(x => x.Size == slotSize && x.Status == SlotStatus.Available);
    }

    public void UpdateSlotStatus(Guid id, SlotStatus slotStatus)
    {
        var slot = _slots.Find(x => x.Id == id);
        if (slot == null)
            throw new ArgumentException("Invalid Slot Id");
        slot.Status = slotStatus;
    }
}
