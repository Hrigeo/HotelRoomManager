namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomsFilterViewModel
    {
        public IEnumerable<RoomsFilterItemViewModel> Items { get; set; } = new List<RoomsFilterItemViewModel>();

        public int? RoomTypeId { get; set; }
        public int? MinCapacity { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages => (TotalCount + PageSize - 1) / PageSize;
        public bool HasPrev => Page > 1;
        public bool HasNext => Page < TotalPages;
    }
}
