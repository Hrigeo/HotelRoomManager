using HotelRoomManager.Contracts;
using HotelRoomManager.Data.Models.User;
using HotelRoomManager.Models;
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
        public async Task<IActionResult> Create(int? roomId)
        {
            var rooms = await roomsService.GetAllAsync();

            var model = new BookingCreateViewModel
            {
                Rooms = rooms.Select(r => new SelectListItem
                {
                    Value = r.Id.ToString(),
                    Text = r.Number
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
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Number });
                return View(model);
            }

            model.GuestId = userManager.GetUserId(User);

            try
            {
                await bookingService.CreateBookingAsync(model);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                var rooms = await roomsService.GetAllAsync();
                model.Rooms = rooms.Select(r => new SelectListItem { Value = r.Id.ToString(), Text = r.Number });
                return View(model);
            }
        }
    }
}
