using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models
{
    public class BookingCreateViewModel : IValidatableObject
    {
        [Required, Display(Name = "Check-in date"), DataType(DataType.Date)]
        public DateTime CheckInDate { get; set; }

        [Required, Display(Name = "Check-out date"), DataType(DataType.Date)]
        public DateTime CheckOutDate { get; set; }

        [Required, Display(Name = "Room")]
        public int RoomId { get; set; }

        // Populated by controller/service to render the dropdown
        public IEnumerable<SelectListItem> Rooms { get; set; } = Enumerable.Empty<SelectListItem>();

        // Extra safety: ensure dates make sense
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
            if (CheckOutDate < CheckInDate)
                yield return new ValidationResult("Check-out must be after check-in.", new[] { nameof(CheckOutDate) });

            if (CheckInDate.Date < DateTime.UtcNow.Date)
                yield return new ValidationResult("Check-in cannot be in the past.", new[] { nameof(CheckInDate) });
        }
    }
}
