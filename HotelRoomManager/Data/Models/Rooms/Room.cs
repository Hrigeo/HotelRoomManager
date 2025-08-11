using HotelRoomManager.Data.Models.Bookings;
using HotelRoomManager.Data.Models.Reviews;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelRoomManager.Emuns.Class;

namespace HotelRoomManager.Data.Models.Rooms
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        public string Number { get; set; } = null!;

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

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();

        [NotMapped]
        public IEnumerable<RoomReview> Reviews =>
            Bookings.Where(b => b.Review != null).Select(b => b.Review!);
    }
}
