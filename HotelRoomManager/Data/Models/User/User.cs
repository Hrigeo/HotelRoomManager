using System.ComponentModel.DataAnnotations;
using HotelRoomManager.Data.Models.Bookings;
using Microsoft.AspNetCore.Identity;

namespace HotelRoomManager.Data.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string? FullName { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
