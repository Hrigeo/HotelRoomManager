using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HotelRoomManager.Contracts;
using HotelRoomManager.Data;
using HotelRoomManager.Data.Models;
using HotelRoomManager.Models.ViewModels.ContactViewModels;
using Microsoft.EntityFrameworkCore;

namespace HotelRoomManager.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext context;
        public ContactService(ApplicationDbContext _context)
        {
            context = _context;
        }


        public async Task CreateAsync(ContactCreateViewModel model)
        {
            var entity = new ContactMessage
            {
                Name = model.Name.Trim(),
                Email = model.Email.Trim(),
                Subject = model.Subject.Trim(),
                Message = model.Message.Trim()
            };
            await context.ContactMessages.AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ContactListItemViewModel>> GetAllAsync(bool? onlyOpen = null)
        {
            var query = context.ContactMessages.AsNoTracking();
            if (onlyOpen == true) query = query.Where(x => !x.IsHandled);

            return await query
                .OrderByDescending(x => x.CreatedOn)
                .Select(x => new ContactListItemViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Email = x.Email,
                    Subject = x.Subject,
                    CreatedOn = x.CreatedOn,
                    IsHandled = x.IsHandled
                })
                .ToListAsync();
        }

        public async Task SetHandledAsync(int id, bool handled)
        {
            var entity = await context.ContactMessages.FindAsync(id);
            if (entity == null) return;            // idempotent
            entity.IsHandled = handled;
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.ContactMessages.FindAsync(id);
            if (entity == null) return;
            context.ContactMessages.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
