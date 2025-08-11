using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using HotelRoomManager.Data.Models.Bookings;

namespace HotelRoomManager.Data.Models.Finance
{
    public class Invoice
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Booking))]
        public int BookingId { get; set; }

        public Booking Booking { get; set; } = null!;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0.0, 100000.0)]
        public decimal Amount { get; set; }

        [Required]
        public DateTime IssuedOn { get; set; } = DateTime.UtcNow;
        public bool IsPaid { get; set; } = false;
    }
}
