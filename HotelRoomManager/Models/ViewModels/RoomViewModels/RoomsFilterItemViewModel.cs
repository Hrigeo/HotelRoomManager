namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomsFilterItemViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public int Capacity { get; set; }
        public decimal PricePerNight { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
        public bool Availability { get; set; }
    }
}
