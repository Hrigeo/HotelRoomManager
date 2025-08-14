namespace HotelRoomManager.Models.ViewModels.ContactViewModels
{
    public class ContactListItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Subject { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; }
        public bool IsHandled { get; set; }
    }
}
