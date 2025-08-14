using System;
using System.ComponentModel.DataAnnotations;
using static HotelRoomManager.Constants.DataConstants;

namespace HotelRoomManager.Data.Models
{
    public class ContactMessage
    {
        public int Id { get; set; }

        [Required, StringLength(NameMaxLength)]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(SubjectMaxLength)]
        public string Subject { get; set; } = string.Empty;

        [Required, StringLength(DescriptionMaxLength)]
        public string Message { get; set; } = string.Empty;

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public bool IsHandled { get; set; } = false;
    }
}

