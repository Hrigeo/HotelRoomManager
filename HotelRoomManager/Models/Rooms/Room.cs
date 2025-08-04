using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelRoomManager.Models.Bookings;
using HotelRoomManager.Models.Amenities;
using static HotelRoomManager.Emuns.Class;

namespace HotelRoomManager.Models.Rooms
{
    public class Room
    {
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
        public int RoomTypeId { get; set; }
        public RoomType RoomType { get; set; } = null!;

        [Required]
        public Availability Availability { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
        public ICollection<RoomAmenityMapping> RoomAmenityMappings { get; set; } = new List<RoomAmenityMapping>();
    }
}
