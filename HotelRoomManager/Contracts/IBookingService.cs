using HotelRoomManager.Models.ViewModels.RoomViewModels;
using HotelRoomManager.Models.ViewModels.BookingViewModel;
using HotelRoomManager.Models.ViewModels.BookingViewModels;

namespace HotelRoomManager.Contracts
{
    public interface IBookingService
    {
        Task CreateBookingAsync(BookingCreateViewModel model);

        Task<RoomDetailsViewModel?> GetDetailsAsync(int id);

        Task<IEnumerable<BookingSimpleViewModel>> GetMyBookingsAsync(string userId);

        // Admin
        Task<IEnumerable<BookingSimpleViewModel>> GetAllAsync();

        // Admin
        Task DeleteAsync(int bookingId);
    }
}
