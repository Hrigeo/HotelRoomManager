using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
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

        public Task CreateAsync(RoomTypeCreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<RoomTypeViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<RoomTypeViewModel?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
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

        public Task UpdateAsync(RoomTypeUpdateViewModel model)
        {
            throw new NotImplementedException();
        }
    }
}
