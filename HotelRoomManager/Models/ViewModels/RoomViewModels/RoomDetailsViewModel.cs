namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public decimal PricePerNight { get; set; }
        public bool Availability { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
        public int RoomTypeCapacity { get; set; }
        public string RoomTypeDescription { get; set; } = string.Empty;
    }
}

