using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Models.View_Models.RoomViewModels;
using HotelRoomManager.Models.ViewModels.Rooms;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Services
{
    public class RoomsService : IRoomsService
    {

        private readonly ApplicationDbContext context;

        public RoomsService(ApplicationDbContext _context)
        {
            context = _context;
        }

        public async Task<IEnumerable<RoomListViewModel>> GetAllAsync()
        {
            var result = context
                .Rooms
                .AsNoTracking()
                .Include(r => r.RoomType)
                .OrderBy(r => r.Number)
                .Select(room => new RoomListViewModel
                  {
                      Id = room.Id,
                      Number = room.Number,
                      Capacity = room.RoomType != null ? room.RoomType.Capacity : 0,
                      PricePerNight = room.PricePerNight,
                      RoomTypeName = room.RoomType != null ? room.RoomType.Name : string.Empty,
                      Availability = room.Availability
                  });

            return await result.ToListAsync();
        }

        public async Task<RoomDetailsViewModel?> GetDetailsAsync(int id)
        {
            return await context.Rooms
                .AsNoTracking()
                .Include(room => room.RoomType)
                .Where(room => room.Id == id)
                .Select(room => new RoomDetailsViewModel
                {
                    Id = room.Id,
                    Number = room.Number,
                    PricePerNight = room.PricePerNight,
                    Availability = room.Availability,

                    RoomTypeId = room.RoomTypeId,
                    RoomTypeName = room.RoomType != null ? room.RoomType.Name : string.Empty,
                    RoomTypeCapacity = room.RoomType != null ? room.RoomType.Capacity : 0,
                    RoomTypeDescription = room.RoomType != null ? room.RoomType.Description : string.Empty
                })
                .FirstOrDefaultAsync();
        }
    }
}
