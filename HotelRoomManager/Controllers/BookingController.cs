using HotelRoomManager.Data;
using HotelRoomManager.Data.Models.Bookings;
using HotelRoomManager.Data.Models.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRoomManager.Controllers
{
    public class BookingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public BookingController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // STEP 2: GET method — shows the form
        [HttpGet]
        public IActionResult Create()
        {
            // Pass a dropdown list of rooms to the view
            ViewBag.Rooms = new SelectList(_context.Rooms.ToList(), "Id", "Number");
            return View();
        }

        // STEP 4: POST method — handles form submission
        [HttpPost]
        public async Task<IActionResult> Create(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                // If validation fails, reload the room dropdown and return to view
                ViewBag.Rooms = new SelectList(_context.Rooms.ToList(), "Id", "Number");
                return View(booking);
            }

            // Assign the current user as the guest
            booking.GuestId = _userManager.GetUserId(User);

            // Add the booking to the DB
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            // Redirect to a page (like MyBookings or Home)
            return RedirectToAction("Index", "Home");
        }
    }
}
