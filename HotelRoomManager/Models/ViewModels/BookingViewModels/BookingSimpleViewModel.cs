using System.ComponentModel.DataAnnotations;

namespace HotelRoomManager.Models.ViewModels.BookingViewModels
{
    public class BookingSimpleViewModel
    {
        public int BookingId { get; set; }

        [Display(Name = "Room")]
        public int RoomNumber { get; set; }

        [Display(Name = "Check-in")]
        public DateTime CheckInDate { get; set; }

        [Display(Name = "Check-out")]
        public DateTime CheckOutDate { get; set; }

        [Display(Name = "Total")]
        public decimal TotalPrice { get; set; }

        public string? UserEmail { get; set; }  // used in Admin view
    }
}

