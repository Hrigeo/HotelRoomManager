using HotelRoomManager.Models;
using HotelRoomManager.Models.ViewModels.Rooms;

namespace HotelRoomManager.Contracts
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateViewModel model);

        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);
    }
}
