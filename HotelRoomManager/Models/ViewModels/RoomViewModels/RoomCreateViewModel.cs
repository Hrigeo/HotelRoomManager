using HotelRoomManager.Data.Models.Rooms;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomCreateViewModel
    {
        [Required, Display(Name = "Room Number")]
        [Range(NumberMin, NumberMax, ErrorMessage = "Room number must be between {1} and {2}.")]
        public int Number { get; set; }

        [Required, Display(Name = "Price per night")]
        [Range(PriceMin, PriceMax, ErrorMessage = "Price per night must be between {1:C} and {2:C}.")]
        public decimal PricePerNight { get; set; }

        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; } = true;

        [Required, Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
