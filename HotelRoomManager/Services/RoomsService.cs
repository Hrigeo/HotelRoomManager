using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Data.Models.Rooms;
using Microsoft.EntityFrameworkCore;
using System;
using HotelRoomManager.Models.ViewModels.RoomViewModels;

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

        public async Task DeleteRoomAsync(int id)
        {
            var entity = await context.Rooms.FindAsync(id);

            if (entity == null)
            {
                throw new ArgumentException("Invalid product");
            }

            context.Rooms.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<int> CreateAsync(RoomCreateViewModel model)
        {
            // Optional uniqueness rule for room number
            var numberTaken = await context.Rooms.AnyAsync(r => r.Number == model.Number);
            if (numberTaken) throw new InvalidOperationException("A room with this number already exists.");

            var entity = new Room
            {
                Number = model.Number,
                PricePerNight = model.PricePerNight,
                Availability = model.IsAvailable,
                RoomTypeId = model.RoomTypeId
            };

            context.Rooms.Add(entity);
            await context.SaveChangesAsync();
            return entity.Id;
        }

        public async Task<RoomEditViewModel?> GetByIdAsync(int id)
        {
            return await context.Rooms
                .AsNoTracking()
                .Where(r => r.Id == id)
                .Select(r => new RoomEditViewModel
                {
                    Id = r.Id,
                    Number = r.Number,
                    PricePerNight = r.PricePerNight,
                    IsAvailable = r.Availability,
                    RoomTypeId = r.RoomTypeId
                })
                .FirstOrDefaultAsync();
        }

        public async Task UpdateAsync(RoomEditViewModel model)
        {
            var entity = await context.Rooms.FindAsync(model.Id)
                         ?? throw new InvalidOperationException("Room not found.");

            if (entity.Number== model.Number)
            {
                var taken = await context.Rooms.AnyAsync(r => r.Number == model.Number && r.Id != model.Id);
                if (taken) throw new InvalidOperationException("A room with this number already exists.");
            }

            entity.Number = model.Number;
            entity.PricePerNight = model.PricePerNight;
            entity.Availability = model.IsAvailable;
            entity.RoomTypeId = model.RoomTypeId;

            await context.SaveChangesAsync();
        }
    }
}
