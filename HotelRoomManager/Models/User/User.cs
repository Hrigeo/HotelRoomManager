using HotelRoomManager.Models.Bookings;
using Microsoft.AspNetCore.Identity;

namespace HotelRoomManager.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = null!;
        public string? Address { get; set; }

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}
