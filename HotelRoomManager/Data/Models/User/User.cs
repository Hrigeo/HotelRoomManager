using System.ComponentModel.DataAnnotations;
using HotelRoomManager.Data.Models.Bookings;
using Microsoft.AspNetCore.Identity;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Data.Models.User
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(NameMaxLength, MinimumLength = NameMinLength)]
        public string FullName { get; set; } = string.Empty;

        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}