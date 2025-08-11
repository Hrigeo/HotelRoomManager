using HotelRoomManager.Data.Models.Bookings;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Data.Models.Reviews
{
    public class RoomReview
    {
            public int Id { get; set; }

            [Required]
            public int BookingId { get; set; }
            public Booking Booking { get; set; } = null!;

            [Required]
            [Range(1, 5)]
            public int Rating { get; set; }

            [MaxLength(500)]
            public string? Comment { get; set; }
    }
}
