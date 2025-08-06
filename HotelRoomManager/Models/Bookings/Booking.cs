using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelRoomManager.Models.Finance;
using HotelRoomManager.Models.Rooms;
using HotelRoomManager.Models.User;

namespace HotelRoomManager.Models.Bookings
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

        [MaxLength(1000)]
        public string? Notes { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal TotalPrice { get; set; }

        public Invoice? Invoice { get; set; }
    }
}
