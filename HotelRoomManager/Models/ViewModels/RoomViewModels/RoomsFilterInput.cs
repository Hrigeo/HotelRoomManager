namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomsFilterInput
    {
        public int? RoomTypeId { get; set; }
        public int? MinCapacity { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
