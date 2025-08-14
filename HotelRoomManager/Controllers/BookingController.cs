using HotelRoomManager.Contracts;
using HotelRoomManager.Data.Models.User;
using HotelRoomManager.Models.ViewModels.BookingViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRoomManager.Controllers
{
    [Authorize]
    public class BookingController : Controller
    {
        private readonly IBookingService bookingService;
        private readonly IRoomsService roomsService;
        private readonly UserManager<ApplicationUser> userManager;

        public BookingController(
            IBookingService bookingService,
            IRoomsService roomsService,
            UserManager<ApplicationUser> userManager)
        {
            this.bookingService = bookingService;
            this.roomsService = roomsService;
            this.userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = userManager.GetUserId(User)!;
            var items = await bookingService.GetMyBookingsAsync(userId);
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Create(int? roomId)
        {
            var rooms = await roomsService.GetAllAsync();

            var model = new BookingCreateViewModel
            {
                Rooms = rooms.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Number.ToString()
                }),
                RoomId = roomId ?? 0
            };
            
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BookingCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var rooms = await roomsService.GetAllAsync();
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Number.ToString() });
                return View(model);
            }

            model.GuestId = userManager.GetUserId(User);

            try
            {
                await bookingService.CreateBookingAsync(model);
                return RedirectToAction("Index", "Booking");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var rooms = await roomsService.GetAllAsync();
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Number.ToString() });
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> All()
        {
            var model = await bookingService.GetAllAsync();
            return View(model);
        }

        // ===== ADMIN: Delete booking =====
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await bookingService.DeleteAsync(id);
                TempData["Success"] = $"Reservation #{id} deleted.";
            }
            catch
            {
                TempData["Error"] = "Failed to delete reservation.";
            }
            return RedirectToAction(nameof(All));
        }


    }
}
