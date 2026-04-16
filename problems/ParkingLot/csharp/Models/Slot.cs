using ParkingLot.Enums;

namespace ParkingLot.Models;

public class Slot
{
    public Slot (SlotSize slotSize, int floorNo)
    {
        Id = Guid.NewGuid();
        Size = slotSize;
        FloorNo = floorNo;
        Status = SlotStatus.Available;
    }

    public Guid Id { get; }
    public SlotSize Size { get; }
    public int FloorNo { get; }
    public SlotStatus Status { get; set; }
}
