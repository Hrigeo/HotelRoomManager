using HotelRoomManager.Models.View_Models.RoomViewModels;
using HotelRoomManager.Models.ViewModels.Rooms;

namespace HotelRoomManager.Contracts
{
    public interface IRoomsService
    {
        Task<IEnumerable<RoomListViewModel>> GetAllAsync();
        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);
    }
}
