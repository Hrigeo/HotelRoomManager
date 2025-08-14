using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Models.ViewModels.ContactViewModels
{
    public class ContactCreateViewModel
    {
        [Required, StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;


        [Required, StringLength(SubjectMaxLength)]
        public string Subject { get; set; } = string.Empty;

        [Required, StringLength(DescriptionMaxLength)]
        public string Message { get; set; } = string.Empty;
    }
}
