using HotelRoomManager.Models.Bookings;
using HotelRoomManager.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelRoomManager.Emuns.Class;

namespace HotelRoomManager.Models.Rooms
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Number { get; set; } = null!;

        [Required]
        [Range(1, 10)]
        public int Capacity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, 10000)]
        public decimal PricePerNight { get; set; }

        [Required]
        [ForeignKey(nameof(RoomType))]
        public int RoomTypeId { get; set; }

        public RoomType RoomType { get; set; } = null!;

        [Required]
        public Availability Availability { get; set; }

        [InverseProperty(nameof(Booking.Room))]
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        [NotMapped]
        public IEnumerable<RoomReview> Reviews =>
            Bookings.Where(b => b.Review != null).Select(b => b.Review!);
    }
}
