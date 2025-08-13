using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Data.Models.Rooms
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string Name { get; set; } = null!;

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Range(CapacityMin, CapacityMax)]
        [Required]
        public int Capacity { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
