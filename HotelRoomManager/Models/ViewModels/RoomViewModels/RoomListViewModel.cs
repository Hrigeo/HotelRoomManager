namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomListViewModel
    {
            public int Id { get; set; }
            public int Number { get; set; }
            public int Capacity { get; set; }
            public decimal PricePerNight { get; set; }
            public string RoomTypeName { get; set; } = string.Empty;
            public bool Availability { get; set; }
    }
}

