using static HotelRoomManager.Emuns.Class;

namespace HotelRoomManager.Models.View_Models.RoomViewModels
{
    public class RoomListViewModel
    {
            public int Id { get; set; }
            public string Number { get; set; } = string.Empty;
            public int Capacity { get; set; }
            public decimal PricePerNight { get; set; }
            public string RoomTypeName { get; set; } = string.Empty;
            public Availability Availability { get; set; }
    }
}

