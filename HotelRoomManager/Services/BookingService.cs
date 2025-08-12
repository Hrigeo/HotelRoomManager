using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Data.Models.Bookings;
using HotelRoomManager.Models;
using HotelRoomManager.Models.ViewModels.Rooms;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Services
{
    /// <summary>
    /// Business logic for creating bookings + reading room details used in the booking flow.
    /// </summary>
    public class BookingService : IBookingService
    {
        private readonly ApplicationDbContext context;

        public BookingService(ApplicationDbContext context) => this.context = context;

        /// <summary>
        /// Create a booking ensuring: valid dates, room exists, and no overlap with existing bookings.
        /// </summary>
        public async Task CreateBookingAsync(BookingCreateViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.GuestId))
                throw new InvalidOperationException("You must be signed in to create a booking.");

            // Ensure room exists and read its nightly price (no tracking needed)
            var room = await context.Rooms.AsNoTracking()
                .FirstOrDefaultAsync(r => r.Id == model.RoomId)
                ?? throw new InvalidOperationException("Selected room does not exist.");

            var checkIn = model.CheckInDate.Date;
            var checkOut = model.CheckOutDate.Date;
            if (checkOut <= checkIn)
                throw new InvalidOperationException("Check-out must be after check-in.");

            // Overlap rule: (startA < endB) && (endA > startB)
            var overlaps = await context.Bookings.AnyAsync(b =>
                b.RoomId == model.RoomId &&
                checkIn < b.CheckOutDate && checkOut > b.CheckInDate);

            if (overlaps)
                throw new InvalidOperationException("That room is already booked for the selected dates.");

            var nights = (checkOut - checkIn).Days;
            var total = nights * room.PricePerNight;

            var entity = new Booking
            {
                RoomId = model.RoomId,
                CheckInDate = checkIn,
                CheckOutDate = checkOut,
                GuestId = model.GuestId!,
                TotalPrice = total
            };

            context.Bookings.Add(entity);
            await context.SaveChangesAsync();
        }

        /// <summary>
        /// Optional helper if your booking flow shows room details.
        /// </summary>
        public async Task<RoomDetailsViewModel?> GetDetailsAsync(int id) =>
            await context.Rooms
                .Include(r => r.RoomType)
                .Where(r => r.Id == id)
                .Select(r => new RoomDetailsViewModel
                {
                    Id = r.Id,
                    Number = r.Number,
                    PricePerNight = r.PricePerNight,
                    Availability = r.Availability,
                    RoomTypeId = r.RoomTypeId,
                    RoomTypeName = r.RoomType != null ? r.RoomType.Name : string.Empty,
                    RoomTypeCapacity = r.RoomType != null ? r.RoomType.Capacity : 0,
                    RoomTypeDescription = r.RoomType != null ? r.RoomType.Description : string.Empty
                })
                .FirstOrDefaultAsync();
    }
}
