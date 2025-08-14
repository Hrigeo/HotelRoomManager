using HotelRoomManager.Models.ViewModels.ContactViewModels;

namespace HotelRoomManager.Contracts
{
    public interface IContactService
    {
        Task CreateAsync(ContactCreateViewModel model);
        Task<IEnumerable<ContactListItemViewModel>> GetAllAsync(bool? onlyOpen = null);
        Task SetHandledAsync(int id, bool handled);
        Task DeleteAsync(int id);
    }
}
