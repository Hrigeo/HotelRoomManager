// ======================= RoomDetailsViewModel.cs =======================
// ViewModel for the Rooms/Details page. Keeps the view decoupled from EF entities.
// Includes RoomType-derived fields so the view doesn't need to navigate entities.
namespace HotelRoomManager.Models.ViewModels.Rooms
{
    public class RoomDetailsViewModel
    {
        public int Id { get; set; }
        public string Number { get; set; } = string.Empty;
        public decimal PricePerNight { get; set; }
        public bool Availability { get; set; }
        public int RoomTypeId { get; set; }
        public string RoomTypeName { get; set; } = string.Empty;
        public int RoomTypeCapacity { get; set; }
        public string RoomTypeDescription { get; set; } = string.Empty;
    }
}

