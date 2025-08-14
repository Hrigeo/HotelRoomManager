using HotelRoomManager.Data.Models.Finance;
using HotelRoomManager.Data.Models.Rooms;
using HotelRoomManager.Data.Models.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Data.Models.Bookings
{
    public class Booking
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime CheckInDate { get; set; }

        [Required]
        public DateTime CheckOutDate { get; set; }

        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }

        public Room Room { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(Guest))]
        public string GuestId { get; set; } = null!;

        public ApplicationUser Guest { get; set; } = null!;

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public Invoice? Invoice { get; set; }
    }
}
