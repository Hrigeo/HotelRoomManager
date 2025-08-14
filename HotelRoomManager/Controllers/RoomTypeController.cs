using HotelRoomManager.Contracts;
using HotelRoomManager.Models.ViewModels.RoomTypeViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelRoomManager.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoomTypeController : Controller
    {
        private readonly IRoomTypeService roomTypeService;

        public RoomTypeController(IRoomTypeService roomTypeService)
        {
            this.roomTypeService = roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var model = await roomTypeService.GetAllAsync();
            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View(new RoomTypeCreateViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RoomTypeCreateViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await roomTypeService.CreateAsync(model);
                TempData["Success"] = "Room type created.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex) // e.g., duplicate name
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await roomTypeService.GetByIdAsync(id);
            if (vm == null) return NotFound();

            var edit = new RoomTypeViewModel
            {
                Id = vm.Id,
                Name = vm.Name,
                Capacity = vm.Capacity,
                Description = vm.Description
            };

            return View(edit);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(RoomTypeViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                await roomTypeService.UpdateAsync(model);
                TempData["Success"] = "Room type updated.";
                return RedirectToAction(nameof(Index));
            }
            catch (InvalidOperationException ex) // e.g., duplicate name
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await roomTypeService.DeleteAsync(id);
                TempData["Success"] = "Room type deleted.";
            }
            catch (InvalidOperationException ex) // e.g., type in use by rooms
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
