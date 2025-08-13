using HotelRoomManager.Models.ViewModels.RoomViewModels;
using HotelRoomManager.Models.ViewModels.BookingViewModel;

namespace HotelRoomManager.Contracts
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateViewModel model);

        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);

        Task<IEnumerable<BookingSimpleView>> GetMyBookingsAsync(string userId);
    }
}
