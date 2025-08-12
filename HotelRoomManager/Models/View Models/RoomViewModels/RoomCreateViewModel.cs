using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models.View_Models.RoomViewModels
{
    public class RoomCreateViewModel
    {
        [Required, Display(Name = "Room Number")]
        public int Number { get; set; } // if your entity uses int, change to int

        [Required, Range(0.01, 100000), Display(Name = "Price per night")]
        public decimal PricePerNight { get; set; }

        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; } = true;

        [Required, Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
