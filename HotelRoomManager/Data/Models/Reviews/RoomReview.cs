using HotelRoomManager.Data.Models.Bookings;
using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Data.Models.Reviews
{
    public class RoomReview
    {
            public int Id { get; set; }

            [Required]
            public int BookingId { get; set; }
            public Booking Booking { get; set; } = null!;

            [Required]
            [Range(RatingMin, RatingMax)]
            public int Rating { get; set; }

            [MaxLength(DescriptionMaxLength)]
            public string? Comment { get; set; }
    }
}
