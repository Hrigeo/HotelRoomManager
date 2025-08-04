using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models.Amenities
{
    public class RoomAmenity
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        [MaxLength(300)]
        public string? Description { get; set; }

        public ICollection<RoomAmenityMapping> RoomAmenityMappings { get; set; } = new List<RoomAmenityMapping>();
    }
}
