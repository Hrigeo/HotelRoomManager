using HotelRoomManager.Models.Rooms;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Models.Amenities
{
    public class RoomAmenityMapping
    {
        [Required]
        public int RoomId { get; set; }
        public Room Room { get; set; } = null!;

        [Required]
        public int AmenityId { get; set; }
        public RoomAmenity Amenity { get; set; } = null!;
    }
}
