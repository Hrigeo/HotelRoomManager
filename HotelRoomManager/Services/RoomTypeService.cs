using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Data.Models.Rooms;
using HotelRoomManager.Models.ViewModels.RoomTypeViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Services
{
    public class RoomTypeService : IRoomTypeService
    {
        private readonly ApplicationDbContext context;
        public RoomTypeService(ApplicationDbContext _context)
        {
                context = _context;
        }

        public async Task CreateAsync(RoomTypeCreateViewModel model)
        {
            var name = model.Name?.Trim() ?? string.Empty;
            var exists = await context.RoomTypes
                .AnyAsync(t => t.Name.ToLower() == name.ToLower());
            if (exists)
            {
                throw new InvalidOperationException("A room type with this name already exists.");
            }

            var entity = new RoomType
            {
                Name = name,
                Capacity = model.Capacity,
                Description = model.Description?.Trim() ?? string.Empty
            };

            await context.RoomTypes.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.RoomTypes
        .Include(t => t.Rooms)
        .FirstOrDefaultAsync(t => t.Id == id);
            if (entity == null) return;

            if (entity.Rooms.Any())
            {
                throw new InvalidOperationException("Cannot delete a type that is in use by rooms.");
            }

            context.RoomTypes.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoomTypeViewModel>> GetAllAsync()
        {
            return await context.RoomTypes
        .AsNoTracking()
        .OrderBy(t => t.Name)
        .Select(t => new RoomTypeViewModel
        {
            Id = t.Id,
            Name = t.Name,
            Capacity = t.Capacity,
            Description = t.Description
        })
        .ToListAsync();
        }

        public async Task<RoomTypeViewModel?> GetByIdAsync(int id)
        {
            return await context.RoomTypes
        .AsNoTracking()
        .Where(t => t.Id == id)
        .Select(t => new RoomTypeViewModel
        {
            Id = t.Id,
            Name = t.Name,
            Capacity = t.Capacity,
            Description = t.Description
        })
        .FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<SelectListItem>> GetSelectListAsync(int? selectedId = null)
        {
            var types = await context.RoomTypes
                .AsNoTracking()
                .OrderBy(rt => rt.Name)
                .Select(rt => new { rt.Id, rt.Name })
                .ToListAsync();

            return types.Select(t => new SelectListItem
            {
                Value = t.Id.ToString(),
                Text = t.Name,
                Selected = selectedId.HasValue && t.Id == selectedId.Value
            });
        }

        public async Task UpdateAsync(RoomTypeViewModel model)
        {
            var entity = await context.RoomTypes.FindAsync(model.Id);
            if (entity == null) throw new KeyNotFoundException("Room type not found.");

            var name = (model.Name ?? string.Empty).Trim();
            var dup = await context.RoomTypes
                .AnyAsync(t => t.Id != model.Id && t.Name.ToLower() == name.ToLower());
            if (dup) throw new InvalidOperationException("A room type with this name already exists.");

            entity.Name = name;
            entity.Capacity = model.Capacity;
            entity.Description = model.Description?.Trim();

            await context.SaveChangesAsync();
        }
    }
}
