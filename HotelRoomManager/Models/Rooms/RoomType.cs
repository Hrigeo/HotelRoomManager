namespace HotelRoomManager.Models.Rooms
{
    public class RoomType
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public ICollection<Room> Rooms { get; set; } = new List<Room>();

    }
}
