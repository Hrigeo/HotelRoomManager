using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models
{
    public class BookingCreateViewModel : IValidatableObject
    {
        [Required, Display(Name = "Check-in date"), DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; } = DateTime.Today;

        [Required, Display(Name = "Check-out date"), DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; } = DateTime.Today.AddDays(1);

        [Required, Display(Name = "Room")]
        public int RoomId { get; set; }

        public string? GuestId { get; set; }
        

        public IEnumerable<SelectListItem> Rooms { get; set; } = Enumerable.Empty<SelectListItem>();
        
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (CheckOutDate < CheckInDate)
                yield return new ValidationResult("Check-out must be after check-in.", new[] { nameof(CheckOutDate) });

            if (CheckInDate.Date < DateTime.UtcNow.Date)
                yield return new ValidationResult("Check-in cannot be in the past.", new[] { nameof(CheckInDate) });
        }
    }
}
