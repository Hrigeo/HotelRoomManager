using System.ComponentModel.DataAnnotations;
using HotelRoomManager.Models.Bookings;
using Microsoft.AspNetCore.Identity;

namespace HotelRoomManager.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [MaxLength(200)]
        public string? Address { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
