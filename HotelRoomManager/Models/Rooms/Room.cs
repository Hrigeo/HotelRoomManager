using HotelRoomManager.Models.Bookings;

namespace HotelRoomManager.Models.Rooms
{
    public class Room
    {
        public int Id { get; set; }

        public string Number { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }

        public RoomType RoomType { get; set; } = null!;
        public int RoomTypeId { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
