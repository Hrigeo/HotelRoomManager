using HotelRoomManager.Data.Models.Bookings;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HotelRoomManager.Models.ViewModels.InvoiceViewModels
{
    public class InvoiceCreateViewModel
    {

        [Required]
        public int BookingId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
    }
}
