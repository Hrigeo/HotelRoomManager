using HotelRoomManager.Models.ViewModels.RoomViewModels;
using HotelRoomManager.Models.ViewModels;

namespace HotelRoomManager.Contracts
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateViewModel model);

        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);
    }
}
