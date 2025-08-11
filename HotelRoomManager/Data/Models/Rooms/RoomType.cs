using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Data.Models.Rooms
{
    public class RoomType
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string Description { get; set; } = null!;

        [Range(1, 10)]
        [Required]
        public int Capacity { get; set; }

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
