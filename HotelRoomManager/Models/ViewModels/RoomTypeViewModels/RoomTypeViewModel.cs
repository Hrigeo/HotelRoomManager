using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models.ViewModels.RoomTypeViewModels
{
    public class RoomTypeViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Type Name")]
        public string Name { get; set; } = string.Empty;

        [Display(Name = "Capacity (people)")]
        public int Capacity { get; set; }

        [Display(Name = "Description")]
        public string? Description { get; set; }
    }
}
