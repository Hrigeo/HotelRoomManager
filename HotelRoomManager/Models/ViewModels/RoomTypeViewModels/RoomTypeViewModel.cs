using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Models.ViewModels.RoomTypeViewModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type Name")]
        [Required, StringLength(NameMaxLength, ErrorMessage = "Name cannot exceed {1} characters.")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Capacity (people)")]
        [Range(CapacityMin, CapacityMax, ErrorMessage = "Capacity must be between {0} and {1}.")]
        public int Capacity { get; set; }

        [Display(Name = "Description")]
        [MaxLength(DescriptionMaxLength, ErrorMessage = "Description cannot exceed {0} characters.")]
        public string? Description { get; set; }
    }
}
