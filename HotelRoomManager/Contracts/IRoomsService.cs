using HotelRoomManager.Models.ViewModels.RoomTypeViewModels;
using HotelRoomManager.Models.ViewModels.RoomViewModels;

namespace HotelRoomManager.Contracts
{
    public interface IRoomsService
    {
        Task<IEnumerable<RoomListViewModel>> GetAllAsync();
        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);
        Task DeleteRoomAsync(int id);

        Task<int> CreateAsync(RoomCreateViewModel model);

        Task<RoomEditViewModel?> GetByIdAsync(int id);

        Task UpdateAsync(RoomEditViewModel model);

        Task<RoomsFilterViewModel> GetPagedAsync(RoomsFilterInput input);
    }
}
