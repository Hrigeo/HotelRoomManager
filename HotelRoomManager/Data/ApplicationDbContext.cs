using HotelRoomManager.Data.Models.Bookings;
using HotelRoomManager.Data.Models.Finance;
using HotelRoomManager.Data.Models.Reviews;
using HotelRoomManager.Data.Models.Rooms;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using static HotelRoomManager.Emuns.Class;

namespace HotelRoomManager.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        modelBuilder.Entity<RoomType>().HasData(
            new RoomType
            {
            Id = 1,
            Name = "Single",
            Capacity = 1,
            Description = "Compact room for solo travelers; efficient and budget-friendly."
            },
            new RoomType
            {
            Id = 2,
            Name = "Double",
            Capacity = 2,
            Description = "Comfortable room for two guests; ideal for couples or friends."
            },
            new RoomType
            {
            Id = 3,
            Name = "Deluxe",
            Capacity = 2,
            Description = "Upgraded amenities with extra comfort for two guests."
            },
            new RoomType
            {
            Id = 4,
            Name = "Family",
            Capacity = 4,
            Description = "Spacious layout suitable for families; extra space and seating."
            }
        );


            modelBuilder.Entity<Room>().HasData(
                new Room { Id = 1, Number = "101", PricePerNight = 89.00m, RoomTypeId = 1, Availability = Availability.Available },
                new Room { Id = 2, Number = "102", PricePerNight = 119.00m, RoomTypeId = 1, Availability = Availability.Available },
                new Room { Id = 3, Number = "201", PricePerNight = 149.00m, RoomTypeId = 2, Availability = Availability.Taken },
                new Room { Id = 4, Number = "202", PricePerNight = 179.00m, RoomTypeId = 2, Availability = Availability.ForCleaning },
                new Room { Id = 5, Number = "301", PricePerNight = 219.00m, RoomTypeId = 3, Availability = Availability.Available },
                new Room { Id = 6, Number = "401", PricePerNight = 240.00m, RoomTypeId = 4, Availability = Availability.Available }
);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<RoomReview> RoomReviews { get; set; }
    }
}
