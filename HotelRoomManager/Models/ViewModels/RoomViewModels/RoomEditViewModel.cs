using HotelRoomManager.Constants;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Models.ViewModels.RoomViewModels
{
    public class RoomEditViewModel
    {
        [HiddenInput]
        public int Id { get; set; }

        [Required]
        [Range(NumberMin, NumberMax, ErrorMessage = "Room number must be between {1} and {2}.")]
        [Display(Name = "Room Number")]
        public int Number { get; set; }

        [Required]
        [Range(PriceMin, PriceMax, ErrorMessage = "Price per night must be between {1:C} and {2:C}.")]

        [Display(Name = "Price per night")]
        public decimal PricePerNight { get; set; }

        [Required]
        [Display(Name = "Availability")]
        public bool IsAvailable { get; set; }

        [Required, Display(Name = "Room Type")]
        public int RoomTypeId { get; set; }

        public IEnumerable<SelectListItem> RoomTypes { get; set; } = Enumerable.Empty<SelectListItem>();

    }
}
