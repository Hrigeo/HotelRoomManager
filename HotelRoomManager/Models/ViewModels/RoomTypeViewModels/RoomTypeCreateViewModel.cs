using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Models.ViewModels.RoomTypeViewModels
{
    public class RoomTypeCreateViewModel
    {
        [Required, StringLength(NameMaxLength)]
        [Display(Name = "Type Name")]
        public string Name { get; set; } = string.Empty;

        [Required, Range(CapacityMin, CapacityMax, ErrorMessage = "Capacity must be between 1 and 20.")]
        [Display(Name = "Capacity (people)")]
        public int Capacity { get; set; }

        [StringLength(DescriptionMaxLength)]
        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
