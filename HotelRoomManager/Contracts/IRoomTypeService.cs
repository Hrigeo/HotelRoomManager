using HotelRoomManager.Models.ViewModels.RoomTypeViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRoomManager.Contracts
{
    public interface IRoomTypeService
    {
        Task<IEnumerable<RoomTypeViewModel>> GetAllAsync();
        Task<RoomTypeViewModel?> GetByIdAsync(int id);
        Task CreateAsync(RoomTypeCreateViewModel model);
        Task UpdateAsync(RoomTypeViewModel model);
        Task DeleteAsync(int id);
        Task<IEnumerable<SelectListItem>> GetSelectListAsync(int? selectedId = null);
    }
}
