using HotelRoomManager.Data.Models.Finance;

namespace HotelRoomManager.Contracts
{
    public interface IInvoiceService
    {
        Task<int> IssueForBookingAsync(int bookingId);

        Task<IEnumerable<Invoice>> GetAllAsync();

        Task<Invoice?> GetByIdAsync(int id);
        Task DeleteAsync(int id);

        Task SetPaidAsync(int id, bool isPaid);

    }
}
