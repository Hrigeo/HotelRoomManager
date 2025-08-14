using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Data.Models.Finance;
using HotelRoomManager.Models.ViewModels.InvoiceViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly ApplicationDbContext context;

        public InvoiceService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<int> IssueForBookingAsync(int bookingId)
        {
            var booking = await context.Bookings
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == bookingId);

            if (booking == null)
                throw new InvalidOperationException("Booking not found.");

            var existing = await context.Invoices
                .AsNoTracking()
                .FirstOrDefaultAsync(i => i.BookingId == bookingId);

            if (existing != null)
                return existing.Id;


            var invoice = new Invoice
            {
                BookingId = bookingId,
                Amount = booking.TotalPrice,
            };

            await context.Invoices.AddAsync(invoice);
            await context.SaveChangesAsync();

            return invoice.Id;
        }

        public async Task<IEnumerable<Invoice>> GetAllAsync()
        {
            // You can project to a view model later; for speed, return entities now.
            return await context.Invoices
                .AsNoTracking()
                .OrderByDescending(i => i.IssuedOn)
                .ToListAsync();
        }

        public async Task<Invoice?> GetByIdAsync(int id)
        {
            return await context.Invoices
                .AsNoTracking()
                .Include(i => i.Booking)
                    .ThenInclude(b => b.Room)
                        .ThenInclude(r => r.RoomType)
                .Include(i => i.Booking)
                    .ThenInclude(b => b.Guest)
                .FirstOrDefaultAsync(i => i.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Invoices.FindAsync(id);
            if (entity == null) return; // idempotent

            context.Invoices.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
