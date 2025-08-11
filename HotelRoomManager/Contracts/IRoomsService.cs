using HotelRoomManager.Models.View_Models.RoomViewModels;

namespace HotelRoomManager.Contracts
{
    public interface IRoomsService
    {
        Task<IEnumerable<RoomListViewModel>> GetAllAsync();
    }
}
