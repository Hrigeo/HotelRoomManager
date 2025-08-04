using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models.Rooms
{
    public class RoomType
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; } = null!;

        [MaxLength(200)]
        public string Description { get; set; } = null!;

        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
