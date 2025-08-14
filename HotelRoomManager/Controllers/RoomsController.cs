using HotelRoomManager.Contracts;
using HotelRoomManager.Data.Models.Rooms;
using HotelRoomManager.Models.ViewModels.RoomTypeViewModels;
using HotelRoomManager.Models.ViewModels.RoomViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace HotelRoomManager.Controllers
{
    public class RoomsController : Controller
    {
        private readonly IRoomsService roomsService;
        private readonly IRoomTypeService roomTypeService;

        public RoomsController(IRoomsService _roomsService, IRoomTypeService _roomTypeService)
        {
            this.roomsService = _roomsService;
            this.roomTypeService = _roomTypeService;
        }

        [HttpGet]
        public async Task<IActionResult> Index([FromQuery] RoomsFilterInput filter)
        {
            var model = await roomsService.GetPagedAsync(filter);
            ViewBag.RoomTypes = await roomTypeService.GetSelectListAsync(filter.RoomTypeId);
            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var model = await roomsService.GetDetailsAsync(id);
            if (model == null) return NotFound();
            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int id)
        {
            await roomsService.DeleteRoomAsync(id);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create()
        {
            var vm = new RoomCreateViewModel
            {
                RoomTypes = await roomTypeService.GetSelectListAsync()
            };


            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(RoomCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = await roomTypeService.GetSelectListAsync(model.RoomTypeId);
                return View(model);
            }

            try
            {
                await roomsService.CreateAsync(model);
                TempData["Success"] = "Room created.";
                return RedirectToAction("Index", "Rooms");
            }
            catch (InvalidOperationException error)
            {
                ModelState.AddModelError(string.Empty, error.Message);
                model.RoomTypes = await roomTypeService.GetSelectListAsync(model.RoomTypeId);
                return View(model);
            }
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(int id)
        {
            var vm = await roomsService.GetByIdAsync(id);
            if (vm == null) return NotFound();

            vm.RoomTypes = await roomTypeService.GetSelectListAsync(vm.RoomTypeId);
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Edit(RoomEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.RoomTypes = await roomTypeService.GetSelectListAsync(model.RoomTypeId);
                return View(model);
            }

            try
            {
                await roomsService.UpdateAsync(model);
                TempData["Success"] = "Room updated.";
                return RedirectToAction("Index", "Rooms");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                model.RoomTypes = await roomTypeService.GetSelectListAsync(model.RoomTypeId);
                return View(model);
            }
        }

    }
}
