using HotelRoomManager.Models;

namespace HotelRoomManager.Contracts
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateViewModel model);
    }
}
