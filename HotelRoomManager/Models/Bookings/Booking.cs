using HotelRoomManager.Models.Rooms;
using HotelRoomManager.Models.User;

namespace HotelRoomManager.Models.Bookings
{
        public class Booking
        {
            public int Id { get; set; }

            public DateTime CheckInDate { get; set; }
            public DateTime CheckOutDate { get; set; }

            public int RoomId { get; set; }
            public Room Room { get; set; } = null!;

            public string GuestId { get; set; } = null!;
            public ApplicationUser Guest { get; set; } = null!;

            public string? Notes { get; set; }
        }
}
